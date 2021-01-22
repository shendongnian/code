    public static Nullable<T> GetNullableValue<T>(this IDataRecord record, int columnIndex, Func<int, T> getValue)
      where T: struct;
    {
      if (record.IsDbNull(columnIndex))
        return null;
      else
        return getValue(columnIndex);
    }
    var xyz = reader.GetNullableValue(0, reader.GetDecimal);
