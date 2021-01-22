    public interface IFactory<T>
    {
        T Create();
    }
    public interface IBuilder<T> : IFactory<T>
    {
        bool HasInstance { get; }
        T Instance { get; }
        void ClearInstance();
    }
    public abstract class Builder<T> : IBuilder<T>
    {
        public static implicit operator T(Builder<T> builder)
        {
            return builder.Instance;
        }
        T _instance;
        public abstract T Create();
        public bool HasInstance { get; private set; }
        public T Instance
        {
            get
            {
                if(!this.HasInstance)
                {
                    _instance = Create();
                    this.HasInstance = true;
                }
                return _instance;
            }
        }
        public void ClearInstance()
        {
            this.HasInstance = false;
            _instance = default(T);
        }
    }
