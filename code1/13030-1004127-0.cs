    CalculateHash(1, 1024, new SHA1CryptoServiceProvider());
    static long CalculateHash(UInt64 repetitions, UInt64 size, HashAlgorithm engine)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[][] goo = new byte[repetitions][];
            for (UInt64 i = 0; i < repetitions; i++)
            {
                goo[i] = new byte[size];
                rng.GetBytes(goo[i]);
            }
            DateTime start = DateTime.Now;
            for (UInt64 i = 0; i < repetitions; i++)
            {
                engine.ComputeHash(goo[i]);
            }
            return DateTime.Now.Subtract(start).Ticks;
        }
