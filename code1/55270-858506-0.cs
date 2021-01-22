    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                Test();
            }
    
            static void Test()
            {
                double[] array = new double[100];
    
                for (int i = 0; i < array.Length; ++i)
                {
                    array[i] = i;
                }
    
                double sum1 = array.Aggregate((total, current) => total + Math.Sqrt(Math.Abs(Math.Sin(current))));
                Console.WriteLine("Linq aggregate = " + sum1);
    
                IParallelEnumerable<double> parray = array.AsParallel();
    
                double sum2 = parray.Aggregate
                (
                    0.0,
                    (total1, current1) => total1 + Math.Sqrt(Math.Abs(Math.Sin(current1))),
                    (total2, current2) => total2 + current2,
                    acc => acc
                );
    
                Console.WriteLine("Plinq aggregate = " + sum2);
            }
        }
    }
