    public T Compute<T> (T param1, T param2, string op) where T : struct
    {
        switch(op)
        {
            case "+":
                return param1 + param2;
            default:
                 throw new NotImplementedException();
        }
    }
    
    public bool Compare<T> (T param1, T param2, string op) where T : struct
    {
        switch (op)
        {
            case "==":
                 return param1 == param2;
            default:
                 throw new NotImplementedException();
        }
    }
