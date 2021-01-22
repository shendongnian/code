    // Extension method, call for any object, eg "if (x.IsNumeric())..."
    public static bool IsNumeric(this object x) { return IsNumeric(x.GetType()); }
    // Method where you know the type of the object
    public static bool IsNumeric(Type type) { return IsNumeric(type, Type.GetTypeCode(type)); }
    // Method where you know the type and the type code of the object
    public static bool IsNumeric(Type type, TypeCode typeCode) { return (typeCode == TypeCode.Decimal || (type.IsPrimitive && typeCode != TypeCode.Object && typeCode != TypeCode.Boolean && typeCode != TypeCode.Char)); }
