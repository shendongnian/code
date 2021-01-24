    const int compareLength = 6;
    const string columnName = "columnName";
    const string otherColumnName = "otherColumnName";
     
    foreach(var row in dataTable.Rows)
    {
        foreach(var otherDataTable in dataTableList)
        {
            foreach(var otherRow in otherDataTable.Rows)
            {
                var value = row[columnName].ToString();
                var otherValue = otherRow[otherColumnName].ToString();
    
                if(otherValue.Length >= compareLength && 
                   value == otherValue.Substring(0, compareLength))
                {
                    /* Do something. */
                }
            }
        }
    }
