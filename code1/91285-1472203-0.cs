    public static void Main()
    {
        int value = 1;
    
        IntEnum i = ToEnum<IntEnum>(value); // Valid cast, runs fine.
        ByteEnum b = ToEnum<ByteEnum>(value); // Invalid cast exception!
    }
    
    public enum ByteEnum : byte { }
    
    public enum IntEnum : int { }
    
    public static TEnum ToEnum<TEnum>(int value)
    {
        return (TEnum)(object)value;
    }
