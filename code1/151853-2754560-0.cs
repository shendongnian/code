    public IEnumerable<IRow> SelectSomeRowsParallel
    {
      DataTable table = GetTableFromDatabase();
      return from DataRow dr in table.Rows.AsParallel()
             select (row => new MySQLRow();
                     row.Fill(row);
                     return row;)
    }
