    public class FilterFactory
    {
        private readonly Func<Type, object> _factoryFunc;
        public FilterFactory(Func<Type, object> factoryFunc)
        {
            _factoryFunc = factoryFunc ?? throw new ArgumentNullException(nameof(factoryFunc));
        }
        public IFilter<T> Create<X, T>() 
        {
            IFilter<T> filter = Create<T>(typeof(X));
            return filter;
        }
        public IFilter<T> Create<T>(Type type) 
        {
            var filter = _factoryFunc(type) as IFilter<T>;
            if (filter == null)
            {
                throw new ArgumentException($"Could not find filter for type '{type.FullName}'");
            }
            return filter;
        }
    }
