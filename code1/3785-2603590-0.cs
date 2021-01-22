            public static bool TryParseStruct<T>(this string value, out Nullable<T> result)
                where T: struct 
            {
                if (string.IsNullOrEmpty(value))
                {
                    result = new Nullable<T>();
                    
                    return true;
                }
    
                result = default(T);
                try
                {
                    IConvertible convertibleString = (IConvertible)value;
                    result = new Nullable<T>((T)convertibleString.ToType(typeof(T), System.Globalization.CultureInfo.CurrentCulture));
                }
                catch(InvalidCastException)
                {
                    return false;
                }
                catch (FormatException)
                {
                    return false;
                }
     
               return true;
            }
