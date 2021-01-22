    class LoggingProxy<T> : RealProxy where T : MarshalByRefObject, new()
    {
      T _innerObject;
      public static T Create()
      {
        LoggingProxy<T> realProxy = new LoggingProxy<T>();
        T transparentProxy = (T)realProxy.GetTransparentProxy();
        return transparentProxy;
      }
      private LoggingProxy() : base(typeof(T))
      {
        _innerObject = new T();
      }
      public override IMessage Invoke(IMessage msg)
      {
        if (msg is IMethodCallMessage)
        {
          IMethodCallMessage methodCall  = msg as IMethodCallMessage;
          System.Diagnostics.Debug.WriteLine("Enter: " + methodCall.MethodName);
          IMessage returnMessage = RemotingServices.ExecuteMessage(_innerObject, msg as IMethodCallMessage);
          System.Diagnostics.Debug.WriteLine("Exit: " + methodCall.MethodName);
          return returnMessage;
        }
        return null;
      }
    }
