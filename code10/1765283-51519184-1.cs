            public static T getAsDigit<T>(this TextBox tb, T min, T max) where T : struct, IComparable<T>
            {
                var valueConverted = default(T);
                try
                {
                   valueConverted = (T)Convert.ChangeType(tb.Text, typeof(T));
                }
                catch(Exception e)
                {
                }
                if (valueConverted.CompareTo(max) > 0)
                    return max;
    
                if (valueConverted.CompareTo(min) < 0)
                    return min;
    
                return valueConverted;
            } 
