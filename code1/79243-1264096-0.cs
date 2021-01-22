    public interface IDependencyResolver : IDisposable
    {
        T GetImplementationOf<T>();
    }
    
    public static class DependencyResolver
    {
        private static IDependencyResolver s_resolver;
    
        public static T GetImplementationOf<T>()
        {
            return s_resolver.GetImplementationOf<T>();
        }
    
        public static void RegisterResolver( IDependencyResolver resolver )
        {
            s_resolver = resolver;
        }
    
        public static void DisposeResolver()
        {
            s_resolver.Dispose();
        }
    }
