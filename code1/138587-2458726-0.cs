    DataTable MakeTableFromRange(Range range)
    {
       table = new DataTable
       for every column in range
       {
          add new column to table
       }
       for every row in range
       {
          add new datarow to table
          for every column in range
          {
             table.cells[column, row].value = range[column, row].value
          }
       }
       return table
    }
