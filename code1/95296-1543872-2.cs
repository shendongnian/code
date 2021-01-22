    public object nullCoalesce(object a, object b, object c)
    {
        return a ?? b ?? c;
    }
    public object ternary(object a, object b, object c)
    {
        return a != null ? a : b != null ? b : c;
    }
    public object ifThenElse(object a, object b, object c)
    {
        if (a != null)
            return a;
        else if (b != null)
            return b;
        else
            return c;
    }
