    public static bool CanChangeType(object value, Type conversionType)
    {
        if (conversionType == null)
        {
            return false;
        }
        if (value == null)
        {              
            return false;
        }
        IConvertible convertible = value as IConvertible;
        if (convertible == null)
        {
            return false;
        }
        return true;
    }
