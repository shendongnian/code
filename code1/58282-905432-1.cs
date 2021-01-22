    DataTable table = new DataTable("ImageTable"); //Create a new DataTable instance.
    
    DataColumn column = new DataColumn("MyImage"); //Create the column.
    column.DataType = System.Type.GetType("System.Byte[]"); //Type byte[] to store image bytes.
    column.AllowDBNull = true;
    column.Caption = "My Image";
    table.Columns.Add(column); //Add the column to the table.
