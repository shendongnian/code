    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[,] arr = { { 20, 9, 11 }, { 30, 5, 6 } };
                Console.WriteLine("before");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write("{0,3}", arr[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("After");
    
                for (int i = 0; i < arr.GetLength(0); i++) // Array Sorting
                {
                    for (int j = arr.GetLength(1) - 1; j > 0; j--)
                    {
    
                        for (int k = 0; k < j; k++)
                        {
                            if (arr[i, k] > arr[i, k + 1])
                            {
                                int temp = arr[i, k];
                                arr[i, k] = arr[i, k + 1];
                                arr[i, k + 1] = temp;
                            }
                        }
                    }
                    Console.WriteLine();
                }
    
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write("{0,3}", arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
