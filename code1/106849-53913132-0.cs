    public static T SafeGet<T>(this System.Data.SqlClient.SqlDataReader reader, string nameOfColumn)
    {
      var indexOfColumn = reader.GetOrdinal(nameOfColumn);
      return reader.IsDBNull(indexOfColumn) ? default(T) : reader.GetFieldValue<T>(indexOfColumn);
    }
