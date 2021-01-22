    class Counter
    {
        public IEnumerable<int> Count(int max)
        {
            int i = 0;
            while (i <= max)
            {
                yield return i;
                i++;
            }
            yield break;
        }
    }
