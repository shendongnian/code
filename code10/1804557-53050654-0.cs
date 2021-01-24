    DataTable newTable = new DataTable("Test");
    // Add column objects to the table. 
    DataColumn ID = new DataColumn();
    ID.DataType = System.Type.GetType("System.Int32");
    ID.ColumnName = "Col1";
    newTable.Columns.Add(ID);
     foreach ( row in your source)               
     {
                DataRow row = newTable.NewRow();
                row["col1"] = modified.ToString();
                newTable.Rows.Add(row);
           
     }
    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))            
            {
                bulkCopy.DestinationTableName = "dbo.test1";
                bulkCopy.WriteToServer(newTable);
            }
