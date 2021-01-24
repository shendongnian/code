    var configuredColumns = new int[] { 5, 22, 24, 27, 29, 32, 34, 37, 39, 43, 45, 48, 50, 54, 56, 59, 61, 65, 67, 71, 73 };   
    // loop over all data rows (ignore first 5 rows which are headers)
    // stop looping if the current row has no data in column 5
    var allRowTexts = new List<string>();
    for (int row = 5; worksheet.Cells[row, 5].Value != null; row++) {
        
        // loop over the configured columns
        var rowText = new StringBuilder();
        foreach (var col in configuredColumns) {
            
            var cell = worksheet.Cells[row, col];
            if (cell.Value == null) {
                rowText.Append("leer" + "\t");
            }
            else {
                rowText.Append(cell.Value.ToString() + "\t");                
            } 
        }
        // rowText now contains all column values for the current row
        allRowTexts.Add(rowText.ToString());
    }
    // write all rows into file
    File.AppendAllLines(Path.Combine(docPath, "Daten2.txt"), allRowTexts); 
