    public T Computation<T> (T param1, T param2, string operator) where T : struct
    {
        switch(operator)
        {
            case "+":
                return param1 + param2;
            etc...
            default:
                 throw new NotImplementedException();
        }
    }
    
    public bool Condition<T> (T param1, T param2, string operator) where T : struct
    {
        switch (operator)
        {
            case "==":
                 return param1 == param2;
            etc...
            default:
                 throw new NotImplementedException();
        }
    }
