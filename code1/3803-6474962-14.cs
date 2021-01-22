    public static T Parse<T>(object value)
    {
    	try { return (T)System.ComponentModel.TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value.ToString()); }
        catch { return default(T); }
    }
