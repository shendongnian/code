    using System.Data.SqlTypes; // from System.Data.dll
    
    public static DateTime RoundToSqlDateTime(DateTime date)
    {
      return DateTime.SpecifyKind( new SqlDateTime(date).Value, date.Kind);
    }
