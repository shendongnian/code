    foreach (DataColumn column in dataTable.Columns) {
      if (column.DataType == typeof(DateTime)) {
        dataTable.Columns.Add(column.ColumnName + "_string", typeof(string));
      }
    }
    foreach (DataRow row in dataTable.Rows) {
       foreach (DataColumn column in dataTable.Columns) {
         if (column.DataType == typeof(DateTime)) {
           row[column.ColumnName + "_string"] = row[column.ColumnName].ToString("dd.MM.yyyy hh:mm:ss");
         }
       }
    }
