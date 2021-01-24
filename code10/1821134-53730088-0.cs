    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] scoreArray = new string[30] { "1", "2", "3", "3", "1", "2", "2", "2", "3", "1", "1", "1", "2", "3", "2", "1", "2", "3", "1", "1", "1", "2", "2", "2", "1", "1", "2", "1", "2","3" };
    
                ulong numScore = ScoreToDecimal(scoreArray);
    
                string saveScore = UDecimalToBase58String(numScore);
    
                Console.WriteLine("Score array: " + String.Join("-",scoreArray));
                Console.WriteLine("Numeric score: " + Convert.ToString(numScore));
                Console.WriteLine("Base58 score: " + saveScore);
    
                ulong numScoreRestored = Base58StringToUDecimal(saveScore);
                string[] scoreArrayRestored = DecimalToScore(numScoreRestored);
    
                Console.WriteLine("From Base58 converted numeric score: " + Convert.ToString(numScoreRestored));
                Console.WriteLine("From Base58 converted score array: " + String.Join("-", scoreArray));
                Console.Read();
            }
    
            /// <summary>
            /// Converts the stars-per-level array to a decimal value for the saved game.
            /// </summary>
            /// <param name="score">score array to convert. Max. 32 entries/levels.</param>
            /// <returns></returns>
            public static ulong ScoreToDecimal(string[] score)
            {
                int arrLength = score.Length;
    
                if (arrLength > 32)
                    throw new ArgumentException("The score array must not be larger than 32 entries");
                    
                ulong result = 0;
    
                for (int i = arrLength - 1; i >= 0; i--)
                {
                    ulong singleScore = Convert.ToUInt64(score[i]);
    
                    if (singleScore > 3)
                        throw new ArgumentException(String.Format("Invalid score value. Max. allowed value is 3, but {0} was given at index {1}", singleScore, i), "score");
    
                    result += (singleScore << ((arrLength - 1 - i) * 2));
                }
    
                return result;
            }
    
            /// <summary>
            /// Converts the decimal value of the saved game back to a stars-per-level array.
            /// </summary>
            /// <param name="decimalScore">Maximal 64-bit unsigned saved game number to convert.</param>
            /// <returns></returns>
            public static string[] DecimalToScore(ulong decimalScore)
            {
                List<string> result = new List<string>();
                while(decimalScore > 0)
                {
                    result.Add(Convert.ToString(decimalScore % 4));
                    decimalScore /= 4;
                }
    
                result.Reverse();
                return result.ToArray();
            }
    
            /// <summary>
            /// Adapted Unsigned-Base58-Version of Pavel Vladovs DecimalToArbitrarySystem function.
            /// See: https://www.pvladov.com/2012/05/decimal-to-arbitrary-numeral-system.html
            /// </summary>
            /// <param name="decimalNumber"></param>
            /// <returns></returns>
            public static string UDecimalToBase58String(ulong decimalNumber)
            {
                const int BitsInLong = 64;
                const int FixedRadix = 58;
                const string Digits = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
    
                if (decimalNumber == 0)
                    return "0";
    
                int index = BitsInLong - 1;
                ulong currentNumber = decimalNumber;
                char[] charArray = new char[BitsInLong];
    
                while (currentNumber != 0)
                {
                    int remainder = (int)(currentNumber % FixedRadix);
                    charArray[index--] = Digits[remainder];
                    currentNumber = currentNumber / FixedRadix;
                }
    
                string result = new String(charArray, index + 1, BitsInLong - index - 1);
    
                return result;
            }
    
            /// <summary>
            /// Adapted Unsigned-Base58-Version of Pavel Vladovs ArbitraryToDecimalSystem function.
            /// See: https://www.pvladov.com/2012/07/arbitrary-to-decimal-numeral-system.html
            /// </summary>
            /// <param name="base58String"></param>
            /// <returns></returns>
            public static ulong Base58StringToUDecimal(string base58String)
            {
                const int FixedRadix = 58;
                const string Digits = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
    
                if (String.IsNullOrEmpty(base58String))
                    return 0;
    
                ulong result = 0;
                ulong multiplier = 1;
                for (int i = base58String.Length - 1; i >= 0; i--)
                {
                    char c = base58String[i];
                    int digit = Digits.IndexOf(c);
                    if (digit == -1)
                        throw new ArgumentException(
                            "Invalid character in the arbitrary numeral system number",
                            "number");
    
                    result += (uint)digit * multiplier;
                    multiplier *= FixedRadix;
                }
    
                return result;
            }
        }
    }
