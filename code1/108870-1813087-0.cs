     public T Create<T>(T c)
     {
        Log.BeginRequest(c, ActionType.Create); 
        Validate(customer);
        WebService.Send(Convert(c));
        Log.EndRequest(c, ActionType.Create); 
     }
