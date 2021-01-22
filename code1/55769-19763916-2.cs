            const int size = 1000;
            const int maxSteps = 100000;
            var randomSeed = (int)(DateTime.UtcNow - new DateTime(1970,1,1,0,0,0).ToLocalTime()).TotalMilliseconds;
            var random = new Random(randomSeed);
            var numOutOfRange = 0;
            var grid = new int[size,size];
            var stopwatch = new Stopwatch();
            Console.WriteLine("---Start test with exception---");
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < maxSteps; i++)
            {
                int coord = random.Next(0, size * 2);
                try
                {
                    grid[coord, coord] = 1;
                }
                catch (IndexOutOfRangeException)
                {
                    numOutOfRange++;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Time used: " + stopwatch.ElapsedMilliseconds + "ms, Number out of range: " + numOutOfRange);
            Console.WriteLine("---End test with exception---");
            
            random = new Random(randomSeed);
            stopwatch.Reset();
            Console.WriteLine("---Start test without exception---");
            numOutOfRange = 0;
            stopwatch.Start();
            for (int i = 0; i < maxSteps; i++)
            {
                int coord = random.Next(0, size * 2);
                if (coord >= grid.GetLength(0) || coord >= grid.GetLength(1))
                {
                    numOutOfRange++;
                    continue;
                }
                grid[coord, coord] = 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Time used: " + stopwatch.ElapsedMilliseconds + "ms, Number out of range: " + numOutOfRange);
            Console.WriteLine("---End test without exception---");
            Console.ReadLine();
