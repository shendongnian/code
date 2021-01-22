        private static void Test(ParallelQuery<int> list)
        {
            var timer = Stopwatch.StartNew();
            if ((from n in list.AsParallel()
                 where IsOdd(n)
                 select n).Count() != (list.Count() / 2))
            {
                throw new Exception("Failed to count the odds");
            }
            Console.WriteLine("Tested " + list.Count() + " numbers in " + timer.Elapsed.TotalSeconds + " seconds");
        }
