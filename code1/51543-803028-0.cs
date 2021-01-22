    public Type GetTypeOrUnderlyingType(object o)
    {
       Type type = o.GetType();
       if(!type.IsGenericType){return type;}
       return type.GetGenericArguments()[0];
    }
