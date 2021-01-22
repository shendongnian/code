    public abstract class Union<T1,T2,T3>
        where T1 : class
        where T2 : class
        where T3 : class
    {
        private readonly T1 _t1;
        private readonly T2 _t2;
        private readonly T3 _t3;
        public Union(T1 t1) { _t1 = t1; }
        public Union(T2 t2) { _t2 = t2; }
        public Union(T3 t3) { _t3 = t3; }
    
        public TResult Match<TResult>(
                Func<T1, TResult> f1,
                Func<T2, TResult> f2,
                Func<T3, TResult> f3
            )
        {
            if (_t1 != null)
            {
                return f1(_t1);
            }
            else if (_t2 != null)
            {
                return f2(_t2);
            }
            else if (_t3 != null)
            {
                return f3(_t3);
            }
            throw new Exception("can't match");
        }
    }
