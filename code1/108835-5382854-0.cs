        private static void Test(ParallelQuery<int> input)
        {
            var timer = new Stopwatch();
            timer.Start();
            
            int size = input.Count();
            if (input.Where(IsOdd).Count() != size / 2)
            {
                throw new Exception("Failed to count the odds");
            }
            timer.Stop();
            
            Console.WriteLine("Tested " + size + " numbers in " + timer.Elapsed.TotalSeconds + " seconds");
        }
