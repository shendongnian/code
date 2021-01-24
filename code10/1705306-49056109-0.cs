    public static T BytesToValue<T>(byte[] buffer)
    {
        Type type = typeof(T);
    
        if (type == typeof(byte))
        {
            // code here.
        }
        else if (type == typeof(short))
        {
           // code here.
        }
    
        // and so on with all other types.
    }
