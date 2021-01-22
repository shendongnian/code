            System.Diagnostics.Stopwatch foo = new System.Diagnostics.Stopwatch();
            
            Decimal x = 1.5M;
            Decimal y = 1;
            int tests = 1000000;
            foo.Start();
            for (int z = 0; z < tests; ++z)
            {
                y = x - Decimal.Truncate(x);
            }
            foo.Stop();
            Console.WriteLine(foo.ElapsedMilliseconds);
            foo.Reset();
            foo.Start();
            for (int z = 0; z < tests; ++z)
            {
                y = x - Math.Floor(x);
            }
            foo.Stop();
            Console.WriteLine(foo.ElapsedMilliseconds);
            Console.ReadKey();
    //Output: 123
    //Output: 164
