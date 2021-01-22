        public static bool Divides(this int potentialFactor, int i)
        {
            return i % potentialFactor == 0;
        }
        public static IEnumerable<int> Factors(this int i)
        {
            foreach (int result in from potentialFactor in Enumerable.Range(1, (int)Math.Sqrt(i))
                                   where potentialFactor.Divides(i)
                                   select potentialFactor)
            {
                yield return result;
                if (i / result != result)
                {
                    yield return i / result;
                }
            }
        }
