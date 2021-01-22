        public static IEnumerable<uint> getFactors(uint x)
        {
            uint max = x / 2;
            for (uint i = 1; i <= max; i++)
            {
                if (0 == (x % i))
                {
                    yield return i;
                }
            }
            yield return x;
        }
