    using (var dataReader = ....)
        {
             while(dataReader.Read())
             {
                 foreach(var item in Params)
                 {
                      row[item.ColumnIndex] = item.Convert(originalDataTable.Rows[rowCounter].ItemArray[item.ColumnIndex]);
                 }
             }
        }
