    public static string ToValueString(this Enum enumValue) 
    {
        if (enumValue.GetType().GetEnumUnderlyingType() == typeof(int))
            return ((int)(object)enumValue).ToString();
        else if (enumValue.GetType().GetEnumUnderlyingType() == typeof(byte))
            return ((byte)(object)enumValue).ToString();
        ... 
    }        
