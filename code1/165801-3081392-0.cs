    public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
    {
        IMethodCallMessage call = msg as IMethodCallMessage;
        var args = call.Args;
        object returnValue = typeof(HelloClass).InvokeMember(call.MethodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, _hello, args);
        return new ReturnMessage(returnValue, args, args.Length, call.LogicalCallContext, call);
    }
