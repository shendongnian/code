    public static string ToValueString<T>(this T enumValue) where T : struct 
    {
        if (enumValue.GetType().GetEnumUnderlyingType() == typeof(int))
            return ((int)(object)enumValue).ToString();
        else if (enumValue.GetType().GetEnumUnderlyingType() == typeof(byte))
            return ((byte)(object)enumValue).ToString();
        ... 
    }        
