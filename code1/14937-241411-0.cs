    public static class Log
    {
       private static readonly ILoggerFactory _loggerFactory =
          IoC.Resolve<ILoggerFactory>();
       public static ILogger For<T>(T instance)
       {
          return For(typeof(T));
       }
       public static ILogger For(Type type)
       {
          return _loggerFactory.GetLoggerFor(type);
       }
    }
