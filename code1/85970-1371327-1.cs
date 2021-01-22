    public class Transform<T, K>
    {
        Func<K, T> _getFunc1;
        Func<K, K, T> _getFunc2;
        Func<K, K, K, T> _getFunc3;
        Action<K, T> _setFunc1;
        Action<K, K, T> _setFunc2;
        Action<K, K, K, T> _setFunc3;
        public T this[K k1]
        {
            get 
            {
                if (_getFunc1 == null) throw new ArgumentException();
                return _getFunc1(k1);
            }
            set 
            {
                if (_getFunc1 == null) throw new ArgumentException();
                _setFunc1(k1, value);
            }
        }
    
        public T this[K k1, K k2]
        {
            get
            {
                if (_getFunc2 == null) throw new ArgumentException();
                return _getFunc2(k1, k2);
            }
            set
            {
                if (_getFunc2 == null) throw new ArgumentException();
                _setFunc2(k1, k2, value);
            }
        }
    
        public T this[K k1, K k2, K k3]
        {
            get
            {
                if (_getFunc3 == null) throw new ArgumentException();
                return _getFunc3(k1, k2, k3);
            }
            set
            {
                if (_getFunc3 == null) throw new ArgumentException();
                _setFunc3(k1, k2, k3, value);
            }
        }
    
        public Transform(Func<K, T> getFunc) { this._getFunc1 = getFunc; }
        public Transform(Func<K, T> getFunc, Action<K, T> setFunc) 
            : this(getFunc)
        {
            this._setFunc1 = setFunc;
        }
        public Transform(Func<K, K, T> getFunc) { this._getFunc2 = getFunc; }
        public Transform(Func<K, K, T> getFunc, Action<K, K, T> setFunc)
            : this(getFunc)
        {
            this._setFunc2 = setFunc;
        }
        public Transform(Func<K, K, K, T> getFunc) { this._getFunc3 = getFunc; }
        public Transform(Func<K, K, K, T> getFunc, Action<K, K, K, T> setFunc)
            : this(getFunc)
        {
            this._setFunc3 = setFunc;
        }
    }
