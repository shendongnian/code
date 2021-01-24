    using System;
    public class Program
    {
        public static readonly string[] Supported = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public static void Main()
        {
            int matrixSize = (int)Math.Ceiling(Math.Sqrt(Supported.Length));
            string[,] matrix = new string[matrixSize, matrixSize];
            for (int i = 0; i < Supported.Length; i++)
            {
                matrix[i / matrixSize, i % matrixSize] = Supported[i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
