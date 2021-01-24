    outputCollection = new DataTable(); // might not be necessary as Blue Prism will generally instantiate the instance for you; remove this line if you're receiving compiler warnings/errors
    // create a column to store your paths
    DataColumn col = new DataColumn();
    col.DataType = System.Type.GetType("System.String")
    col.ColumnName = "Filename";
    outputCollection.Columns.Add(col);
    // loop through the String[] array and place the values in the DataTable structure
    foreach (String el in str) {
        DataRow row = outputCollection.NewRow();
        row["Filename"] = el;
        outputCollection.Rows.Add(row);
    }
