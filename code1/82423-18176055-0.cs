    public class NotifierInterceptor : IInterceptor
        {
            private PropertyChangedEventHandler handler;
            public static Dictionary<String, PropertyChangedEventArgs> _cache =
              new Dictionary<string, PropertyChangedEventArgs>();
    
            public void Intercept(IInvocation invocation)
            {
                switch (invocation.Method.Name)
                {
                    case "add_PropertyChanged":
                        handler = (PropertyChangedEventHandler)
                                  Delegate.Combine(handler, (Delegate)invocation.Arguments[0]);
                        invocation.ReturnValue = handler;
                        break;
                    case "remove_PropertyChanged":
                        handler = (PropertyChangedEventHandler)
                                  Delegate.Remove(handler, (Delegate)invocation.Arguments[0]);
                        invocation.ReturnValue = handler;
                        break;
                    default:
                        if (invocation.Method.Name.StartsWith("set_"))
                        {
                            invocation.Proceed();
                            if (handler != null)
                            {
                                var arg = retrievePropertyChangedArg(invocation.Method.Name);
                                handler(invocation.Proxy, arg);
                            }
                        }
                        else invocation.Proceed();
                        break;
                }
            }
    
            private static PropertyChangedEventArgs retrievePropertyChangedArg(String methodName)
            {
                PropertyChangedEventArgs arg = null;
                _cache.TryGetValue(methodName, out arg);
                if (arg == null)
                {
                    arg = new PropertyChangedEventArgs(methodName.Substring(4));
                    _cache.Add(methodName, arg);
                }
                return arg;
            }
        }
    	
