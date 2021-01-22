    public bool IsGreaterThanZero(object value)
    {
        if(value is IConvertible)
        {
            return Convert.ToDouble(value) > 0.0;
        }
        return false;
    }
