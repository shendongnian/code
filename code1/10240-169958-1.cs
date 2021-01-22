    using System;
    using System.Diagnostics;
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("First is just for JIT...");
            Test(10,10);
            Console.WriteLine("Real numbers...");
            Test(1000,1000);
    
            Console.ReadLine();
        }
    
        static void Test(int size, int repeat)
        {
            Console.WriteLine("Size {0}, Repeat {1}", size, repeat);
            int[,] rect = new int[size, size];
            int[][] jagged = new int[size][];
            for (int i = 0; i < size; i++)
            { // don't cound this in the metrics...
                jagged[i] = new int[size];
            }
            Stopwatch watch = Stopwatch.StartNew();
            for (int cycle = 0; cycle < repeat; cycle++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        rect[i, j] = i * j;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("\tint[,] set: " + watch.ElapsedMilliseconds);
    
            int sum = 0;
            watch = Stopwatch.StartNew();
            for (int cycle = 0; cycle < repeat; cycle++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sum += rect[i, j];
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("\tint[,] get: {0} (chk={1})", watch.ElapsedMilliseconds, sum);
    
            watch = Stopwatch.StartNew();
            for (int cycle = 0; cycle < repeat; cycle++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        jagged[i][j] = i * j;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("\tint[][] set: " + watch.ElapsedMilliseconds);
    
            sum = 0;
            watch = Stopwatch.StartNew();
            for (int cycle = 0; cycle < repeat; cycle++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sum += jagged[i][j];
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("\tint[][] get: {0} (chk={1})", watch.ElapsedMilliseconds, sum);
        }
    }
