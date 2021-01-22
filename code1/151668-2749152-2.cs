    // we'll use these to check for rows with nulls
    var columns = yourTable.Columns
        .Cast<DataColumn>();
    // say the column you want to sort by is called "Date"
    var rows = yourTable.Select("", "Date ASC"); // or "Date DESC"
    using (var writer = new StreamWriter(yourPath)) {
        for (int i = 0; i < rows.Length; i++) {
            DataRow row = rows[i];
            
            // check for any null cells
            if (columns.Any(column => row.IsNull(column)))
                continue;
            
            string[] textCells = row.ItemArray
                .Select(cell => cell.ToString()) // may need to pick a text qualifier here
                .ToArray();
            // check for non-null but EMPTY cells
            if (textCells.Any(text => string.IsNullOrEmpty(text)))
                continue;
        
            writer.WriteLine(string.Join(",", textCells));
        }
    }
