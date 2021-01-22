    public class FooService : IFooService {
      public FooService(ILogger<FooService> logger) { ... }
    }
If you're adamantly against the ILogger&lt;T&gt; interface, you could do something more creative, like a custom provider, which reads the IContext to determine the parent type.
    public class GenericLogger : ILogger {
      public class GenericLogger(Type type) { ... }
    }
    
    public class LoggerProvider : Provider<ILogger> {
      public override ILogger CreateInstance(IContext context) {
        return new GenericLogger(context.Target.Member.ReflectedType);
      }
    }
