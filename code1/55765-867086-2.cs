        static void Main(string[] args)
        {
            Stopwatch withCatch = new Stopwatch();
            Stopwatch withoutCatch = new Stopwatch();
            int iterations = 20000;
            for (int i = 0; i < iterations; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write("{0}%", 100 * i / iterations);
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                }
                CatchIt(withCatch, withoutCatch);
            }
            Console.WriteLine("With: {0}ms", ((float)(withCatch.ElapsedMilliseconds)) / iterations);
            Console.WriteLine("Without: {0}ms", ((float)(withoutCatch.ElapsedMilliseconds)) / iterations);
            Console.WriteLine("Percent difference: {0}%", 100 * withCatch.ElapsedMilliseconds / withoutCatch.ElapsedMilliseconds);
            Console.ReadKey(true);
        }
        static void CatchIt(Stopwatch withCatch, Stopwatch withoutCatch)
        {
            withCatch.Start();
            try
            {
                FinallyIt(withoutCatch);
            }
            catch
            {
            }
            withCatch.Stop();
        }
        static void FinallyIt(Stopwatch withoutCatch)
        {
            try
            {
                withoutCatch.Start();
                ThrowIt(withoutCatch);
            }
            finally
            {
                withoutCatch.Stop();
            }
        }
        private static void ThrowIt(Stopwatch withoutCatch)
        {
            throw new NotImplementedException();
        }
