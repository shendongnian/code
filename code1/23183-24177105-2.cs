    private static void MeasureNewTime()
        {
            var data = new double[Size];
            var rng = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rng.NextDouble();
            }
            Console.WriteLine("Lenght of array: {0}", data.Length);
            Console.WriteLine("No. of iteration: {0}", Iterations);
            Console.WriteLine(" ");
            double correctSum = data.Sum();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                double sum = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    sum += data[j];
                }
                if (Math.Abs(sum - correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("For loop with Array: {0}", sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                double sum = 0;
                foreach (double d in data)
                {
                    sum += d;
                }
                if (Math.Abs(sum - correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("Foreach loop with Array: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine(" ");
            var dataList = data.ToList();
            sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                double sum = 0;
                for (int j = 0; j < dataList.Count; j++)
                {
                    sum += data[j];
                }
                if (Math.Abs(sum - correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("For loop with List: {0}", sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                double sum = 0;
                foreach (double d in dataList)
                {
                    sum += d;
                }
                if (Math.Abs(sum - correctSum) > 0.1)
                {
                    Console.WriteLine("Summation failed");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine("Foreach loop with List: {0}", sw.ElapsedMilliseconds);
        }
