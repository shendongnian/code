    public static class ScopeFactoryExtension
    {
       public static EventHandler<BasicDeliverEventArgs> WrapInScope(this IServiceScopeFactory scopeFactory, Func<IMyScopedService, object, BasicDeliverEventArgs, Task> func)
       {
          async void InScope(object arg1, BasicDeliverEventArgs arg2)
          {
             using (var scope = scopeFactory.CreateScope())
             {
                await func(scope, arg1, arg2);
             }
          }
    
          return InScope;
       }
    }
