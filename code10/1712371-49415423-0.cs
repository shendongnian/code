    public class CustomMySqlDbDependencyResolver : IDbDependencyResolver
    {
        private readonly Assembly _executingAssembly = Assembly.GetExecutingAssembly();
        private readonly MySqlDependencyResolver _mySqlResolver = new MySqlDependencyResolver();
        
        public object GetService(Type type, object key)
        {
            var stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames().Skip(1).ToArray();
            bool shouldResolve = stackFrames.Any(f => f.GetMethod().DeclaringType.Assembly.Equals(_executingAssembly));
            if (!shouldResolve)
            {
                return null;
            }
            var resolvedService = _mySqlResolver.GetService(type, key);
            return resolvedService;
        }
        public IEnumerable<object> GetServices(Type type, object key)
        {
            var service = GetService(type, key);
            if (service != null)
            {
                yield return service;
            }
        }
    }
