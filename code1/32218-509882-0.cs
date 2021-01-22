    using Excel = Microsoft.Office.Interop.Excel;
    
    ...
    
    worksheet = workbook.Worksheets[1] as Excel.Worksheet;
    
    Excel.Range range;
    range = worksheet.get_Range("A1", "A5") as Excel.Range;
    foreach (Excel.Range cell in range.Cells)
    {
        myComboBox.Items.Add(cell.Value2 as string);
    }
