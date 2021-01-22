    Excel.Range range = (Excel.Range)excelApp.Selection;
    List<int> rowNumbers = new List<int>();
    
    // Enumerate the Rows within each Area of the Range.
    foreach (Excel.Range area in range.Areas)
    {
        foreach (Excel.Range row in area.Rows)
        {
            rowNumbers.Add(row.Row);
        }
    }
    
    // Report the results.
    foreach (int rowNumber in rowNumbers)
    {
        MessageBox.Show(rowNumber.ToString());
    }
