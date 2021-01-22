    [LogRequest(ActionType.Create)]
    [DoValidate()]
    public T Create<T>(T item)
    {
       WebService.Send(convert(item));
    }
