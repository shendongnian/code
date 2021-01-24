    public class Try<T> {
      // Assuming NInject, but same applies to any other container
      [Inject]
      ILogger Logger { get; set; }
      
      private Try() {
        // stops anyone from outside this project from creating an instance of Try
      }
      
      public static Exceptional<T> Do(Action f) {
        Try<T> t = new Try<T>();
        return t.DoPrivate<T>(f);
      }
    
      private Exceptional<T> DoPrivate<T>(Action f) {
        // This is an instance method, so has access to the injected logger
        try {
          return f();
        } catch (Exception ex) {
          Logger.Log(ex.Message);
          return ex;
        }
      }
    }
