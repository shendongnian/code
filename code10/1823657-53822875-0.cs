        private static void Main(string[] args)
        {
            // Any value > 3 here causes Parallel.ForEach to hang on the yield return
            var partitioner = Partitioner.Create(getWorkItems(), EnumerablePartitionerOptions.NoBuffering);
            System.Threading.Tasks.Parallel.ForEach(partitioner,
                new System.Threading.Tasks.ParallelOptions { MaxDegreeOfParallelism = 1  },
                (workItem) =>
                {
                    System.Console.WriteLine($"      Parallel start:  {workItem}");
                    workCount--;
                    System.Console.WriteLine($"      Parallel finish: {workItem}");
                    inProcess = false;
                });
            System.Console.WriteLine($"=================== Finished ===================\r\n");
            var s = System.Console.ReadLine();
        }
