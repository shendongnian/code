    public class Path
    {
        private readonly Item[] path;
        private int _currentIndex;
        public Path(string pathElements)
        {
            path = pathElements.Select(t => new Item(t)).ToArray();
            _currentIndex = 0;
        }
        public ItemType MoveToNext(int increase)
        {
            _currentIndex += increase;
            if (_currentIndex > path.Length)
            {
                _currentIndex -= path.Length;
            }
            if (_currentIndex < 0)
            {
                _currentIndex += path.Length;
            }
            return path[_currentIndex].Collect();
        }
        public int GetPosition()
        {
            return _currentIndex;
        }
    }
