    public class NotifierInterceptor : IInterceptor
    {
      private PropertyChangedEventHandler handler;
      public static Dictionary<String, PropertyChangedEventArgs> _cache =
        new  Dictionary<string, PropertyChangedEventArgs>();
     
      public void Intercept(IInvocation invocation)
      {
        //Each subscription to the PropertyChangedEventHandler is intercepted (add)
        if (invocation.Method.Name == "add_PropertyChanged")
        {
          handler = (PropertyChangedEventHandler)
                Delegate.Combine(handler, (Delegate)invocation.Arguments[0]);
          invocation.ReturnValue = handler;
        }
        //Each de-subscription to the PropertyChangedEventHandler is intercepted (remove)
        else if (invocation.Method.Name == "remove_PropertyChanged")
        {
          handler = (PropertyChangedEventHandler)
             Delegate.Remove(handler, (Delegate)invocation.Arguments[0]);
          invocation.ReturnValue = handler;
        }
        //Each setter raise a PropertyChanged event
        else if (invocation.Method.Name.StartsWith("set_"))
        {
          //Do the setter execution
          invocation.Proceed();
          //Launch the event after the execution
          if (handler != null)
          {
            PropertyChangedEventArgs arg =
              retrievePropertyChangedArg(invocation.Method.Name);
            handler(invocation.Proxy, arg);
          }
        }
        else invocation.Proceed();
      }
     
      // Caches the PropertyChangedEventArgs
      private PropertyChangedEventArgs retrievePropertyChangedArg(String methodName)
      {
        PropertyChangedEventArgs arg = null;
        NotifierInterceptor._cache.TryGetValue(methodName, out arg);
        if (arg == null)
        {
          arg = new  PropertyChangedEventArgs(methodName.Substring(4));
          NotifierInterceptor._cache.Add(methodName, arg);
        }
        return arg;
      }
    }
