    public class DependencyResolver
    {
        private static readonly AsyncLocal<Func<Type, object>> _resolverFunc = new AsyncLocal<Func<Type, object>>();
    
        public static DependencyResolver Current { get; set; }
    
        public Func<Type, object> ResolverFunc
        {
            get => _resolverFunc.Value;
            set => _resolverFunc.Value = value;
        }
    
        public T GetService<T>()
        {
            return (T)ResolverFunc(typeof(T));
        }
    }
