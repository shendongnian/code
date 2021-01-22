    /// <summary>
    /// Wraps IEnumerable in Stack like wrapper
    /// </summary>
    public class EnumerableStack<T>
    {
        private enum StackState
        {
            Pending,
            HasItem,
            Empty
        }
    
        private readonly IEnumerator<T> _enumerator;
    
        private StackState _state = StackState.Pending;
    
        public EnumerableStack(IEnumerable<T> xs)
        {
            _enumerator = xs.GetEnumerator();
        }
    
        public T Pop()
        {
            var res = Peek(isEmptyMessage: "Cannot Pop from empty EnumerableStack");
            _state = StackState.Pending;
            return res;
        }
    
        public T Peek()
        {
            return Peek(isEmptyMessage: "Cannot Peek from empty EnumerableStack");
        }
    
        public bool IsEmpty
        {
            get
            {
                if (_state == StackState.Empty) return true;
                if (_state == StackState.HasItem) return false;
                ReadNext();
                return _state == StackState.Empty;
            }
        }
    
        private T Peek(string isEmptyMessage)
        {
            if (_state != StackState.HasItem)
            {
                if (_state == StackState.Empty) throw new InvalidOperationException(isEmptyMessage);
                ReadNext();
                if (_state == StackState.Empty) throw new InvalidOperationException(isEmptyMessage);
            }
            return _enumerator.Current;
        }
    
        private void ReadNext()
        {
            _state = _enumerator.MoveNext() ? StackState.HasItem : StackState.Empty;
        }
    }
