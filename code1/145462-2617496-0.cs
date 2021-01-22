    public class Stack<T>
    {
        public int Count { get; private set; }
        private int _CurrentPosition;
        private T[] _Values;
    
        public Stack(int capacity)
        {
            _CurrentPosition = -1;
            _Values = new T[capacity];
            Count = capacity;
        }
    
        public T Peek()
        {
            if (_CurrentPosition < 0)
                return default(T);
    
            return _Values[_CurrentPosition];
        }
    
        public void Push(T item)
        {
            if (_CurrentPosition == Count)
                throw new Exception("Stack overflow...");
    
            _CurrentPosition++;
            _Values[_CurrentPosition] = item;
        }
    
        public T Pop()
        {
            if(_CurrentPosition < 0)
                throw new Exception("Stack underflow...");
            T item = _Values[_CurrentPosition];
            _Values[_CurrentPosition] = default(T);
            _CurrentPosition--;
            return item;
        }
    }
