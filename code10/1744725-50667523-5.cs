    List<DataColumn> MergeColumns(DataTable dt1, DataTable dt2)
    {
      var cols = new List<DataColumn>();
      foreach (DataColumn c in dt1.Columns) cols.Add(new DataColumn(c.ColumnName, c.DataType));
      foreach (DataColumn c in dt2.Columns) cols.Add(new DataColumn(c.ColumnName, c.DataType));
      return cols;
    }
