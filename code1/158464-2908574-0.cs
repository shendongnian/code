    class ArrayWrapper<T>
    {
        private T[] _array;
        public ArrayWrapper(T[] array)
        {
            _array = array;
        }
        
        private int? _hashcode;
        public override int GetHashCode()
        {
            if (!_hashcode.HasValue)
            {
                _hashcode = ComputeHashCode();
            }
            return _hashcode.Value;
        }
        
        public override bool Equals(object other)
        {
            // Your equality logic here
        }
        
        protected virtual int ComputeHashCode()
        {
            // Your hashcode logic here
        }
        
        public int Length
        {
            get { return _array.Length; }
        }
        
        public T this[int index]
        {
            get { return _array[index]; }
            set
            {
                _array[index] = value;
                // Invalidate the hashcode when data is modified
                _hashcode = null;
            }
        }
    }
