    public static DataTable SortByGrade(DataTable table,
      string columnToSort, SortDirection sortDirection) 
    {
      IEnumerable<DataRow> query = 
        from row in table.AsEnumerable()
        orderby ConvertGrade(row[columnToSort].ToString())
        select row;
      if (sortDirection == "DESC")
      {
        query = query.Reverse();
      }
    
      DataTable result = query.CopyToDataTable();
      return result;
    }
