    public sealed class Lazy<T>
    {
        Func<T> getValue;
        T value;
        object lockValue = new object();
    
        public Lazy(Func<T> f)
        {
            getValue = () =>
                {
                    lock (lockValue)
                    {
                        value = f();
                        getValue = () => value;
                    }
                    return value;
                };
        }
    
        public T Force()
        {
            return getValue();
        }
    }
