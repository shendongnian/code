    Microsoft.Office.Interop.Excel.Worksheet sheet = newWorkbook.ActiveSheet;
    if ( sheet != null )
    {
        Microsoft.Office.Interop.Excel.Range range = sheet.UsedRange;
        if ( range != null )
        {
            int nRows = usedRange.Rows.Count;
            int nCols = usedRange.Columns.Count;
            foreach ( Microsoft.Office.Interop.Excel.Range row in usedRange.Rows )
            {
                string value = row.Cells[0].FormattedValue as string;
            }
        }
     }
