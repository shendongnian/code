    class TableResults
    {
      public int sortField
    }
    from t in context.Table select new TableResults { sortField = 0 }
