    public static bool IsNumericType(Type type)
    {
      TypeCode typeCode = Type.GetTypeCode(type);
      //The TypeCode of numerical types are between SByte (5) and Decimal (15).
      return (int)typeCode >= 5 && (int)typeCode <= 15;
    }
