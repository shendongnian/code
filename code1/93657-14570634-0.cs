    public static class LinqExtension
    {
      public static void Truncate<TEntity>(this Table<TEntity> table) where TEntity : class
      {
        var rowType = table.GetType().GetGenericArguments()[0];
        var tableName = table.Context.Mapping.GetTable(rowType).TableName;
        var sqlCommand = String.Format("TRUNCATE TABLE {0}", tableName);
        table.Context.ExecuteCommand(sqlCommand);
      }
    }
