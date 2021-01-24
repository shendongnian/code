        public class AndroidLogService : ILogService
    {
        public ILogger GetLogger(string name)
        {
            return new AndroidLogger(name);
        }
        public ILogger GetLogger(Type typeName)
        {
            return GetLogger(typeName.Name);
        }
        public ILogger GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }
    }
