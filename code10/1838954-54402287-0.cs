    public static bool IsDefaultEnum<T>(T enumVal) where T: System.Enum
    { 
        var val = typeof(T).GetField("Default").GetValue(enumVal);
		return val.Equals(enumVal);
    }
