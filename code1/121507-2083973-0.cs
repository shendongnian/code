       // Create a new DataTable and set two DataColumn objects as primary keys.
       DataTable myTable = new DataTable();
       DataColumn myColumn = new DataColumn();
       myColumn.DataType = System.Type.GetType("System.Guid");
       myColumn.ColumnName= "ID";
       // Add the column to the DataTable.Columns collection.
       myTable.Columns.Add(myColumn);
       // Set the PrimaryKeys property to the array.
       myTable.PrimaryKey = myColumn;
