    class StringGrid {
        // just a sample storage
        // might actually work if you only need to address whole rows
        // but not whole columns
        private readonly Dictionary<int, Dictionary<int, string>> _values = new Dictionary<int, Dictionary<int, string>>();
        // indexer 
        public string this[int x, int y]
        {
            get
            {
                // various checks omited
                return _values[x][y];
            }
            set
            {
                if (!_values.ContainsKey(x))
                    _values.Add(x, new Dictionary<int, string>());
                _values[x][y] = value;
            }
        }
    }
