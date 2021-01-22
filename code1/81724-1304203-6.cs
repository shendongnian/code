    public abstract class Builder<T>
    {
        public static implicit operator T(Builder<T> builder)
        {
            return builder.Build();
        }
        private bool _built;
        public T Build()
        {
            if(_built)
            {
                throw new InvalidOperationException("Instance already built");
            }
            _built = true;
            return GetInstance();
        }
        protected abstract T GetInstance();
    }
