    public T Create<T>(T t)
    {
        Log.BeginRequest(t, ActionType.Create); 
        Validate(t);
        WebService.Send(Convert(t));
        Log.EndRequest(t, ActionType.Create);
        return t;
    }
