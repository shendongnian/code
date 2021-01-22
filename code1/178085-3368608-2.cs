    public class Stack<T>
    {
        private const int _defaultSize = 4;
        private const int _growthMultiplier = 2;
    
        private T[] _elements;
        private int _index;
        private int _limit;
    
    
        public Stack()
        {
            _elements = new T[_defaultSize];
            _index = -1;
            _limit = _elements.Length - 1;
        }
    
    
        public void Push(T item)
        {
            if (_index == _limit)
            {
                var temp = _elements;
                _elements = new T[_elements.Length * _growthMultiplier];
                _limit = _elements.Length - 1;
                Array.Copy(temp, _elements, temp.Length);
            }
            _elements[++_index] = item;
        }
    
        public T Pop()
        {
            if (_index < 0)
                throw new InvalidOperationException();
    
            var item = _elements[_index];
            _elements[_index--] = default(T);
            return item;
        }
    
        public void Clear()
        {
            _index = 0;
            Array.Clear(_elements, 0, _elements.Length);
        }
    }
