    foreach (DataColumn column in dt.Columns)
    {    
        //Add the Header row for CSV file.
        csv += column.ColumnName + ',';
    }   
    //Add new line.
    csv += Environment.NewLine;     
    foreach (DataColumn column in dt.Columns)
    {
        csv += $"{column.ExtendedProperties["Description"]},";
    }
    //Add new line.
    csv += Environment.NewLine;     
