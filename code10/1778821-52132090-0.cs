    // A helper class that resolves services using built-in ASP.NET Core service provider.
    public static class AspectServiceLocator
    {
        private static IServiceProvider serviceProvider;
        public static void Initialize(IWebHost host)
        {
            serviceProvider = host.Services;
        }
        public static Lazy<T> GetService<T>() where T : class
        {
            return new Lazy<T>(GetServiceImpl<T>);
        }
        private static T GetServiceImpl<T>()
        {
            if (serviceProvider == null)
                throw new InvalidOperationException();
            return (T) serviceProvider.GetService(typeof(T));
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            // Initialize the AspectServiceLocator during ASP.NET Core program start-up
            AspectServiceLocator.Initialize(host);
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    [PSerializable]
    public class CacheAttribute : MethodInterceptionAspect
    {
        private static Lazy<IMemoryCache> cache;
        static CacheAttribute()
        {
            // Use AspectServiceLocator to initialize the cache service field at application run-time.
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                cache = AspectServiceLocator.GetService<IMemoryCache>();
            }
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            object cacheKey = args.Method.Name;
            object cachedResult;
            if (cache.Value.TryGetValue(cacheKey, out cachedResult))
            {
                args.ReturnValue = cachedResult;
                return;
            }
            args.Proceed();
            cache.Value.Set(cacheKey, args.ReturnValue);
        }
    }
