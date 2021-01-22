    public IEnumerable<IRow> SelectSomeRowsParallel
            {
              DataTable table = GetTableFromDatabase();
              return from DataRow dr in table.Rows.AsParallel()
                     select (row => 
                             var mysqlRow = new MySQLRow()
                             mysqlRow.Fill(row);
                             return mysqlRow;)
            }
