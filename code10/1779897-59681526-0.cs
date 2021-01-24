    public bool AreEqualConvert(object o1, object o2)
    {
        if (ReferenceEquals(o1, o2))
        {
            return true;
        }
    
        if (o1 is null || o2 is null)
        {
            return false;
        }
    
        if (o1.GetType() == o2.GetType())
        {
            return o1.Equals(o2);
        }
    
        switch (o1)
        {
            case float f1:
                switch (o2)
                {
                    case double d2:
                        return f1 == d2;
                    case IConvertible c2:
                        return f1 == c2.ToSingle(null);
                    default:
                        return false;
                }
    
            case double d1:
                return o2 is IConvertible conv2
                    ? d1 == conv2.ToDouble(null)
                    : false;
    
            case IConvertible c1:
                switch (o2)
                {
                    case float f2:
                        return c1.ToSingle(null) == f2;
                    case double d2:
                        return c1.ToDouble(null) == d2;
                    case IConvertible c2:
                        return c1.ToDecimal(null) == c2.ToDecimal(null);
                    default:
                        return false;
                }
    
            default:
                return false;
        }
    }
