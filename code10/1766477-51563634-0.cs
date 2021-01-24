    foreach (DataRow row in table.Rows)
    {
        // Loop through the cell values
        foreach (object item in row.ItemArray) 
        {
           // Get the cell value
           string cellValue = item.ToString();
           // Remove unwanted characters
           cellValue = cellValue.Replace(":","");
           cellValue = cellValue.Replace("/","");
           cellValue = cellValue.Replace("?","");
           cellValue = cellValue.Replace("*","");
           cellValue = cellValue.Replace("[","");
           cellValue = cellValue.Replace("]","");
           cellValue = cellValue.Replace("'","");
        {
    }
