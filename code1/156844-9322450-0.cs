    using System.Data.SqlTypes; // from System.Data.dll
    public static DateTime RoundToSqlDateTime(DateTime date)
    {
      return new SqlDateTime(date).Value;
    }
