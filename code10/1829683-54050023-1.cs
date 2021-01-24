    public MyReturn <bool> TryAddService(Type type, object service)
    {
        if (service == null)
            return new MyReturn <bool> {Message = "Your messgage"};
        //and etc...
        return new MyReturn <bool>();
    }
