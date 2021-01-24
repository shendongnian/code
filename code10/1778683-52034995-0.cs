        static async void SumAsync(byte[] bytes)
        {
            readingLength = bytes.Length / TaskCount;
            int sum = 0;
            Console.WriteLine("Running...");
    
            Stopwatch watch = new Stopwatch();
    
            watch.Start();
            var results = new Task[TaskCount];
            for (int i = 0; i < TaskCount; i++)
            {
                Task<int> task = SumPortion(bytes.SubArray(i * readingLength, readingLength));
                results[i] = task
            }
            int[] result = await Task.WhenAll(results);
            watch.Stop();
    
            Console.WriteLine("Done! Time took: {0}, Result: {1}", watch.ElapsedMilliseconds, result.Sum());
    
        }
