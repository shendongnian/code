    class LambdaComparer<T> : IEqualityComparer<T>
    {
        readonly Func<T, T, bool> _lambdaComparer;
        readonly Func<T, int> _lambdaHash;
    
        public LambdaComparer(Func<T, T, bool> lambdaComparer) :
            this(lambdaComparer, o => 0){}
    
        public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
        {
            _lambdaComparer = lambdaComparer ?? throw new ArgumentNullException(nameof(lambdaComparer));
            _lambdaHash = lambdaHash ?? throw new ArgumentNullException(nameof(lambdaHash));
        }
    
        public bool Equals(T x, T y) => _lambdaComparer(x, y);
        public int GetHashCode(T obj) => _lambdaHash(obj);
    }
