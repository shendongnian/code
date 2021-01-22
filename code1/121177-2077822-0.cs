    int columnIndex = 2; // desired column index
    // for loop approach		
    string[] results = new string[dt.Rows.Count];
    for (int index = 0; index < dt.Rows.Count; index++)
    {
        results[index] = dt.Rows[index][columnIndex].ToString();
    }
    // LINQ
    var result = dt.Rows.Cast<DataRow>()
                        .Select(row => row[columnIndex].ToString())
                        .ToArray();
