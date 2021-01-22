       // Create a new DataTable and set two DataColumn objects as primary keys.
       DataTable myTable = new DataTable();
       DataColumn[] keys = new DataColumn[1];
       DataColumn myColumn = new DataColumn();
       myColumn.DataType = System.Type.GetType("System.Guid");
       myColumn.ColumnName= "ID";
       // Add the column to the DataTable.Columns collection.
       myTable.Columns.Add(myColumn);
       keys[0] = myColumn;
       // Set the PrimaryKeys property to the array.
       myTable.PrimaryKey = keys;
