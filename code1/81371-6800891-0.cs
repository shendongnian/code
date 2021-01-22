    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace PyramidUsingForLoops
    {
        class StarPyramid
        {
            static void Main(string[] args)
            {
                int Row = 5;
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Row-(i+1); j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < 2*i+1; k++)
                    {
                         Console.Write("*");
                    }
                    Console.WriteLine();
                
                }
                Console.ReadLine();
            }
        }
    }
