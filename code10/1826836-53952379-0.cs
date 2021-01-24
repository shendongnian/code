    public class StringListManager
    {
        private readonly object _lock = new object();
        private readonly List<string> _theStrings = new List<string>();
        private int _index = 0;
        //maybe you want to do this in a constructor??
        public void Initialize(IEnumerable<string> strings)
        {
            lock (_lock)
            {
                _theStrings.AddRange(strings);
            }
        }
        public string GetNextString()
        {
            lock (_lock)
            {
                var count = _theStrings.Count;
                if (count == 0)
                {
                    return null; //or an empty string, your choice
                }
                var result = _theStrings[_index];
                ++_index;
                if (_index >= count)
                {
                    _index = 0;
                }
                return result;
            }
        }
        public void ClearStrings()
        {
            lock (_lock)
            {
                _theStrings.Clear();
            }
        }
    }
