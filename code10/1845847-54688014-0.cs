    var configuredColumns = new int[] { 5, 22, 24, 27, 29, 32, 34, 37, 39, 43, 45, 48, 50, 54, 56, 59, 61, 65, 67, 71, 73 };   
    // loop all rows
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
        // rowtext now contains all column values
        allRowTexts.Add(rowText.ToString());
    }
    // write all rows into file
    File.AppendAllLines(Path.Combine(docPath, "Daten2.txt"), allRowTexts);        
