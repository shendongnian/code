      public interface IGetLog<T> { }
    
      public static class IGetLogExtension
      {
        public static ILog GetLogger<T>(this IGetLog<T> getLog)
        {
          return LogManager.GetLogger(typeof(T));
        }
      }
