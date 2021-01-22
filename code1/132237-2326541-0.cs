    public static bool AreAllCellsEmpty(DataRow row)
    {
      if (row == null) throw new ArgumentNullException("row");
      for (int i = row.Table.Columns.Count - 1; i >= 0; i--)
        if (!row.IsNull(i))
          return false;
      return true;
    }
