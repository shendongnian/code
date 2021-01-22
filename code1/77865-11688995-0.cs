    private static readonly Random random = new Random();
            private static readonly object syncLock = new object();
            public int RandomNumber(int min, int max)
            {
                lock (syncLock)
                { // synchronize
                    return random.Next(min, max);
                }
            }
