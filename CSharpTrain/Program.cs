/****************************************************************************
 * Copyleft (L) 2022, All Rights Not Reserved
 * You may use, distribute and modify this code.
 ****************************************************************************/

/**
 * @file Program.cs
 * @author Utku Oruç
 * @date 31 March 2022
 *
 * @brief <b> P.I Works Problem Solution </b>
 *
 * Solution of the Euler problem
 *
 * @see https://github.com/utkuoruc
 * @see https://www.linkedin.com/in/utkuoruc/
 */

using System;

namespace Solution
{
	public static class PIWorks
	{

		/**
		*
		*	  @name   toArr (string[] lines)
		*
		*	  @brief A function to convert given string into 2D int array
		**/
		public static int[,] toArr(string[] lines)
		{
			int[,] arr = new int[lines.Length, lines.Length + 1];

			int row = 0;

			while (row < lines.Length)
			{
				var chr = lines[row].Trim().Split(' ');

				for (int column = 0; column < chr.Length; column++)
				{
					int number;
					int.TryParse(chr[column], out number);
					arr[row, column] = number;
				}
				row++;
			}
			return arr;
		}

		/**
		*
		*	  @name   getLines (String input)
		*
		*	  @brief Split the lines to receive numbers
		**/
		public static String[] getLines(String input)
		{
			return input.Split('\n');
		}

		/**
		*
		*	  @name   avoidPrimes (int[,] arr)
		*
		*	  @brief A function to avoid prime numbers in solution
		**/
		private static int[,] avoidPrimes(int[,] arr)
		{
			int length = arr.GetLength(0);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (IsPrime(arr[i, j]))
					{
						arr[i, j] = -1;
					}
				}
			}
			return arr;
		}
		/**
		*
		*	  @name   Solution (string input)
		*
		*	  @brief Solution of the problem, do required steps for the solution of the problem
		*	  
		**/
		public static int Solution(string input){
			string[] lines = getLines(input);

			int[,] arr = toArr(lines);


			int length = arr.GetLength(0);

			arr = avoidPrimes(arr);

			for (int n = length - 2; n >= 0; n--)
			{

				for (int i = 0; i < length; i++)
				{
					if (!(IsPrime(arr[n, i])))
					{
						if (arr[n + 1, i] >= arr[n + 1, i + 1] && arr[n + 1, i] != -1)
							arr[n, i] = arr[n, i] + arr[n + 1, i];

						else if (arr[n + 1, i] == -1 && arr[n + 1, i + 1] == -1)
							arr[n, i] = -1;

						else if (arr[n + 1, i] <= arr[n + 1, i + 1] && arr[n + 1, i] != -1)
							arr[n, i] = arr[n, i] + arr[n + 1, i + 1];

						else if (arr[n + 1, i] >= arr[n + 1, i + 1] && IsPrime(arr[n + 1, i]))
							arr[n, i] = arr[n, i] + arr[n + 1, i + 1];

						else
							arr[n, i] = arr[n, i] + arr[n + 1, i + 1];
					}
				}
			}
			if(arr[0, 0] <= 0)
				return 0;
            else return arr[0, 0];
		}

		/**
		*
		*	  @name   Main
		*
		*	  @brief A main function for testing purposes
		**/
		public static void Main()
		{
			const string input = @"   215
                                  193 124
                                  117 237 442
                                  218 935 347 235
                                  320 804 522 417 345
                                  229 601 723 835 133 124
                                  248 202 277 433 207 263 257
                                  359 464 504 528 516 716 871 182
                                  461 441 426 656 863 560 380 171 923
                                  381 348 573 533 447 632 387 176 975 449
                                  223 711 445 645 245 543 931 532 937 541 444
                                  330 131 333 928 377 733 017 778 839 168 197 197
                                  131 171 522 137 217 224 291 413 528 520 227 229 928
                                  223 626 034 683 839 053 627 310 713 999 629 817 410 121
                                  924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
            
			Console.WriteLine(Solution(input));

		}


		/**
		*
		*	  @name   IsPrime (int number)
		*
		*	  @brief Check if the number is prime or not
		**/
		public static bool IsPrime(int number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}