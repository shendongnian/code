            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (i != 0)
                {
                    int k = 10 / i;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"With Checking: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i < int.MaxValue; i++)
            {
                try
                {
                    int k = 10 / i;
                }
                catch (Exception)
                {
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"With Exception: {stopwatch.ElapsedMilliseconds}");
