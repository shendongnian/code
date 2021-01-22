    Drawing.Bitmap img = new Drawing.Bitmap("Path to image"); //Replace string with your OpenFileDialog path.
    DataColumn column = new DataColumn("ImageColumn");
    column.DataType = System.Type.GetType("System.Drawing.Bitmap");
    //Code to add data to a cell:
    DataRow row = new DataRow();
    row("ImageColumn") = img;
