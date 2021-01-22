	public static Nullable<T> ToNullable<T>(this string s) where T: struct
    {
        if (!string.IsNullOrWhiteSpace(s))
        {
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
			
            return (T)conv.ConvertFrom(s);
        }
		
        return default(Nullable<T>);
    }
