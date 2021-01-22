    HashSet<Type> NumericTypes = new HashSet<Type>
    {
        typeof(decimal), typeof(byte), typeof(sbyte),
        typeof(short), typeof(ushort), ...
    };
    
    public static bool IsNumeric(Type myType)
    {
       return NumericTypes.Contains(Nullable.GetUnderlyingType(myType) ?? myType);
    }
