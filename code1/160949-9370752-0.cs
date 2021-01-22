    private static object DeserializeValue(string value, Type type)
    {
      switch (Type.GetTypeCode(type))
      {
        case TypeCode.Empty:
          return null;
        case TypeCode.DBNull:
          return DBNull.Value;
        case TypeCode.Object:
        case TypeCode.String:
          return value;
        default:
          {
            var convertible = value as IConvertible;
            return convertible.ToType(type, null);
          }
      }
    }
