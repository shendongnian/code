    public abstract class Builder<T> : IBuilder<T>
    {
        public static implicit operator T(Builder<T> builder)
        {
            return builder.Instance;
        }
        private T _instance;
        public bool HasInstance { get; private set; }
        public T Instance
        {
            get
            {
                if(!HasInstance)
                {
                    _instance = CreateInstance();
                    HasInstance = true;
                }
                return _instance;
            }
        }
        protected abstract T CreateInstance();
        public void ClearInstance()
        {
            _instance = default(T);
            HasInstance = false;
        }
    }
