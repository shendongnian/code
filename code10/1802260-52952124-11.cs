    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    namespace Benchmarks
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
    
            public double GetDistanceFrom(Point p)
            {
                double dx, dy;
                dx = p.X - X;
                dy = p.Y - Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }
        }
    
        [ClrJob(baseline: true)]
        public class SomeVsMany
        {
            [Params(1000)]
            public static int inputDataSize = 1000;
    
            [Params(10)]
            public static int searchDataSize = 10;
    
            static Point[] inputData = new Point[inputDataSize];
            static Point[] searchData = new Point[searchDataSize];
            static Point[] resultData = new Point[searchDataSize];
    
            [GlobalSetup]
            public static void Setup()
            {
                GenerateRandomData(inputData);
                GenerateRandomData(searchData);
            }
    
            [Benchmark]
            public static void AllThreadSearch()
            {
                List<Thread> threads = new List<Thread>();
                for (int i = 0; i < searchDataSize; i++)
                {
                    var thread = new Thread(
                        obj =>
                        {
                            int index = (int)obj;
                            SearchOne(index);
                        });
                    thread.Start(i);
                    threads.Add(thread);
                }
                foreach (var t in threads) t.Join();
            }
    
            [Benchmark]
            public static void FewThreadSearch()
            {
                int threadCount = Environment.ProcessorCount;
                int workSize = searchDataSize / threadCount;
                List<Thread> threads = new List<Thread>();
                for (int i = 0; i < threadCount; i++)
                {
                    var thread = new Thread(
                        obj =>
                        {
                            int[] range = (int[])obj;
                            int from = range[0];
                            int to = range[1];
                            for (int index = from; index < to; index++)
                            {
                                SearchOne(index);
                            }
                        }
                        );
                    int rangeFrom = workSize * i;
                    int rangeTo = workSize * (i + 1);
                    thread.Start(new int[] { rangeFrom, rangeTo });
                    threads.Add(thread);
                }
                foreach (var t in threads) t.Join();
            }
    
            [Benchmark]
            public static void ParallelThreadSearch()
            {
                System.Threading.Tasks.Parallel.For(0, searchDataSize,
                        index =>
                        {
                            SearchOne(index);
                        });
            }
    
            private static void GenerateRandomData(Point[] array)
            {
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new Point()
                    {
                        X = rand.NextDouble() * 100_000,
                        Y = rand.NextDouble() * 100_000
                    };
                }
            }
    
            private static void SearchOne(int i)
            {
                var searchPoint = searchData[i];
                foreach (var p in inputData)
                {
                    if (resultData[i] == null)
                    {
                        resultData[i] = p;
                    }
                    else
                    {
                        double oldDistance = searchPoint.GetDistanceFrom(resultData[i]);
                        double newDistance = searchPoint.GetDistanceFrom(p);
                        if (newDistance < oldDistance)
                        {
                            resultData[i] = p;
                        }
                    }
                }
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<SomeVsMany>();
            }
        }
    }
