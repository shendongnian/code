    public T Create<T>(T c, Action<T> validate, Func<T, string> convert)
    {
        Log.BeginRequest(c, ActionType.Create);
     
        validate(c);
        WebService.Send(convert(c));
    
        Log.EndRequest(c, ActionType.Create);
    }
