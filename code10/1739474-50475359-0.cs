    public bool Value1Exists
    {
        get
        {
            return Value1 != null
        }
    }
    ...
    public bool HasItems
    {
        get
        {
            if (Value1Exists || Value2Exists || ...)
                 return true;
            else
                return false;
        }
    }
