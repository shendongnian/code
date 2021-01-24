    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int[,] original = new int[,] { {  1,  2,  3,  4 }, 
                                           {  5,  6,  7,  8 }, 
                                           {  9, 10, 11, 12 }, 
                                           { 13, 14, 15, 16 } };
            int[,] harder = new int[,] { {  1,  2,  3,  4,  5,  6,  7,  8,  9 },
                                         { 10, 11, 12, 13, 14, 15, 16, 17, 18 },
                                         { 19, 20, 21, 22, 23, 24, 25, 26, 27 },
                                         { 28, 29, 30, 31, 32, 33, 34, 35, 36 },
                                         { 37, 38, 39, 40, 41, 42, 43, 44, 45 },
                                         { 46, 47, 48, 49, 50, 51, 52, 53, 54 },
                                         { 55, 56, 57, 58, 59, 60, 61, 62, 63 },
                                         { 64, 65, 66, 67, 68, 69, 70, 71, 72 },
                                         { 73, 74, 75, 76, 77, 78, 79, 80, 81 } };
            IterateArray(original);
            Console.ReadLine();
        }
        static void IterateArray(int[,] array)
        {
            double tDim = Math.Sqrt(Math.Sqrt(array.Length));
            int dim = (int)tDim;
            if (dim != tDim) throw new ArgumentException("Not a valid array!");
            for (int i = 0; i < dim; i++)
            {
                IterateRows(array, dim, i);
            }
        }
        static void IterateRows(int[,] array, int dim, int pass)
        {
            int maxRow = dim * dim;
            IList<int> list = new List<int>(maxRow);
            for (int curRow = 0; curRow < maxRow; curRow++)
            {
                IterateColumns(array, dim, curRow, pass, list);
                if (list.Count == maxRow)
                {
                    PrintNewArray(list, dim);
                    list.Clear();
                }
            }
        }
        static void IterateColumns(int[,] array, int dim, int row, int pass, IList<int> list)
        {
            int maxCol = dim + (dim * pass);
            for (int curCol = pass * dim; curCol < maxCol; curCol++)
            {
                list.Add(array[row, curCol]);
            }
        }
        static void PrintNewArray(IList<int> list, int dim)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (i % dim == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine($"\nAverage {list.Average()}");
        }
    }
