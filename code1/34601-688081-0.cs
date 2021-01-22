        private Func<T, T, bool> _equals;
        private Func<T, int> _hashCode;
        public DelegateComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            _equals= equals;
            _hashCode = hashCode;
        }
        public bool Equals(T x, T y)
        {
            return _equals(x, y);
        }
        public int GetHashCode(T obj)
        {
            if(_hashCode!=null)
                return _hashCode(obj);
            return obj.GetHashCode();
        }       
    }
