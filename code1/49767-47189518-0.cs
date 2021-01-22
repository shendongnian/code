    using System.ComponentModel;
    public static Nullable<T> ToNullable<T>(this string s) where T : struct
    {
        var ret = new Nullable<T>();
        var conv = TypeDescriptor.GetConverter(typeof(T));
        
        if (!conv.CanConvertFrom(typeof(string)))
        {
            throw new NotSupportedException();
        }
        
        if (conv.IsValid(s))
        {
            ret = (T)conv.ConvertFrom(s);
        }
        
        return ret;
    }
