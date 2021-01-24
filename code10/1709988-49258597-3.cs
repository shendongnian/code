    foreach(DataTable dt in dset.Tables)
    {
      //then you can get the rows and columns values for each table as above
       foreach (DataRow row in dt.Rows)
       {
           childRow = new Dictionary<string, object>();
           foreach (DataColumn col in dt.Columns)
           {
              childRow.Add(col.ColumnName, row[col]);
           }
           parentRow.Add(childRow);
       }
    }
