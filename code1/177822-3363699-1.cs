    int count = 0;
    
    DataTable table = DataSet.Tables[tableName];
    foreach (DataRow row in table.Rows)
    {
       string completed = (string)row["COMPLEATED_ON"];
       if (!string.IsNullOrEmpty(completed))
       {
          count++;
       }
    }
