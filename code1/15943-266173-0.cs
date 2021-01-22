    static bool IsZeroOrEmpty(object o1)
    {
        object ZeroValue = 0;
    
        if(o1 == null)
            return false;
        
        if(o1.GetType().IsValueType)
        {
            return (o1 as System.ValueType).Equals(Convert.ChangeType(ZeroValue, o1.GetType()))
        }
        else
        {
            if (o1.GetType() == typeof(String))
            {
                return o1.Equals(String.Empty);
            }
        }
    }
