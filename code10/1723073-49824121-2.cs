    public abstract class AbstractFilter<T> : IFilter
    {
        T p;
        protected AbstractFilter(T filterParams)
        {
            p = filterParams;
        }
        public abstract void Apply(ref Mat buffer);
    }
