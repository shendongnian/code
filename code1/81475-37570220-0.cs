    public class Stringable<T>
    {
        private T _obj;
        private Func<T, string> _convertFn;
        public Stringable(T obj, Func<T, string> convertFn)
        {
            _obj = obj;
            _convertFn = convertFn;
        }
        public T GetObj() { return _obj; }
        public override string ToString() { return _convertFn(_obj); }
    }
