    public virtual DataTable GetData()
    {
     DataTable dtTemp = //...get data from sql
     DataTable dt = PostTransform(dtTemp);
     return dt;
    }
    
    private DataTable PostTransform(DataTable inputDt)
    {
     DataTable dt = inputDt.Clone();
    
     foreach (var item in Params)
     {
      if (item.ColumnType != null)
      {
       foreach (var columnName in item.ColumnName)
       {
        dt.Columns[columnName].DataType = item.ColumnType;
       }
      }
     }
    
     int rowCounter = 0;
    
     foreach (DataRow row in inputDt.Rows)
     {
      DataRow newRow = dt.Rows.Add(inputDt.Rows[rowCounter].ItemArray);
    
      foreach (var item in Params)
      {
       foreach (var columnName in item.ColumnName)
       {
        newRow[columnName] = item.Convertor.Convert(row[columnName]);
       }
      }
    
      ++rowCounter;
     }
    
     return dt;
    }
