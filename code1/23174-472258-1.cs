    using System;
    using System.Diagnostics;
    using System.Linq;
    
    class Test
    {
        const int Size = 1000000;
        const int Iterations = 10000;
    
        static void Main()
        {
            double[] data = new double[Size];
            Random rng = new Random();
            for (int i=0; i < data.Length; i++)
            {
                data[i] = rng.NextDouble();
            }
    
            double correctSum = data.Sum();
    
            Stopwatch sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                double sum = 0;
                for (int j=0; j < data.Length; j++)
                {
                    sum += data[j];
                }
                if (Math.Abs(sum-correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("For loop: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                double sum = 0;
                foreach (double d in data)
                {
                    sum += d;
                }
                if (Math.Abs(sum-correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("Foreach loop: {0}", sw.ElapsedMilliseconds);
        }
    }
