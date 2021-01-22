    private class DataContainer
    {
        private readonly int[,] _data;
        private HashSet<int> _index;
    
        public DataContainer(int[,] data)
        {
            _data = data;
        }
    
        public bool Contains(int value)
        {
    
            if (_index == null)
            {
                _index = new HashSet<int>();
                for (int i = 0; i < _data.GetLength(0); i++)
                {
                    for (int j = 0; j < _data.GetLength(1); j++)
                    {
                        _index.Add(_data[i, j]);
                    }
                }
            }
            return _index.Contains(value);
        }
    }
