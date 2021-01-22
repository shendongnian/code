        public static IEnumerable<uint> getFactors(uint x)
        {
            for (uint i = 1; i*i <= x; i++)
            {
                if (0 == (x % i))
                {
                    yield return i;
                    if (i != (x / i))
                    {
                        yield return x / i;
                    }
                }
            }
        }
