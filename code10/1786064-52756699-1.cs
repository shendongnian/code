    public class Injector
    {
        private readonly Assembly _assembly;
        private readonly IServiceProvider _serviceProvider;
        public Injector(IServiceProvider serviceProvider)
        {
            _assembly = Assembly.GetEntryAssembly();
            _serviceProvider = serviceProvider;
        }
        public object RunMethod(string className, string methodName, params object[] parameters)
        {
            var classType = _assembly
                .GetType(className);
            object instance = _serviceProvider.GetService(classType);
            var method = classType.GetMethod(methodName);
            var result = method.Invoke(instance, parameters);
            return result;
        }
    }
