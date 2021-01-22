    public void ProcessMessage(object message)
    {
        Type messageType = message.GetType();
        MethodInfo method = this.GetType().GetMethod("GenericProcessMessage");
        MethodInfo closedMethod = method.MakeGenericMethod(messageType);
        closedMethod.Invoke(this, new object[] {message});
    }
