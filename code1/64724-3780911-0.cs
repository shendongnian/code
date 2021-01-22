    public class UniqueRandoms : IEnumerable<int>
    {
        Random _rand = new Random();
        List<int> _candidates;
        public UniqueRandoms(int maxInclusive)
            : this(1, maxInclusive)
        { }
        public UniqueRandoms(int minInclusive, int maxInclusive)
        {
            _candidates = 
                Enumerable.Range(minInclusive, maxInclusive - minInclusive + 1).ToList();
        }
        public IEnumerator<int> GetEnumerator()
        {
            while (_candidates.Count > 0)
            {
                int index = _rand.Next(_candidates.Count);
                yield return _candidates[index];
                _candidates.RemoveAt(index);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
