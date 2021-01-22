    private static List<IServiceCallback> subscribers = new List<IServiceCallback>();
    public void Join(string userName)
    {
        IServiceCallback callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
        foreach (var serviceCallback in subscribers)
        {
            serviceCallback.UserJoined(userName);
        }
    
        subscribers.Add(callback);
    }
