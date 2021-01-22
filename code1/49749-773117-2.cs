    public static Nullable<T> ToNullable<T>(this string s) where T: struct
    {
        Nullable<T> result = new Nullable<T>();
        try
        {
            if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                result = (T)conv.ConvertFrom(s);
            }
        }
        catch { } 
        return result;
    }
