    static bool IsZeroOrEmpty(object o1)
    {
        bool Passed = false;
        object ZeroValue = 0;
    
        if(o1 != null)
        {
            if(o1.GetType().IsValueType)
            {
                Passed = (o1 as System.ValueType).Equals(Convert.ChangeType(ZeroValue, o1.GetType()))
            }
            else
            {
                if (o1.GetType() == typeof(String))
                {
                    Passed = o1.Equals(String.Empty);
                }
            }
        }
        return Passed;
    }
