        public static bool Divides(this int potentialFactor, int i)
        {
            return i % potentialFactor == 0;
        }
        public static IEnumerable<int> Factors(this int i)
        {
            return from potentialFactor in Enumerable.Range(1, i)
                   where potentialFactor.Divides(i)
                   select potentialFactor;
        }
