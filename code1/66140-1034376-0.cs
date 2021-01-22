    private static readonly Dictionary<TypeCode,int> TypeCodeLength =
        new Dictionary<TypeCode,int> {
        { TypeCode.Int32, 4 },
        { TypeCode.Int64, 8 },
        { TypeCode.Char, 2 },
        // etc
    }
