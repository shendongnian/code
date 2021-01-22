        static bool IsZeroOrEmpty(object o1)
        {
            if (o1 == null)
                return false;
            if (o1.GetType().IsValueType)
            {                
                return (o1 as System.ValueType).Equals(0);
            }
            else
            {
                if (o1.GetType() == typeof(String))
                {
                    return o1.Equals(String.Empty);
                }
                return o1.Equals(0);
            }
        }
