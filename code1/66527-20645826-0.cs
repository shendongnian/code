        wSheet = (Excel._Worksheet)wBook.ActiveSheet;
        Microsoft.Office.Interop.Excel.Range cells = wSheet.Cells;
        int iRowCount = 2;
        // enumerate and drop the values straight into the Excel file
        while (data.Read())
        {
            Microsoft.Office.Interop.Excel.Range cell = cells[iRowCount, 1];
            cell  = data["fullname"].ToString();
            Marshal.FinalReleaseComObject(cell);
        }
        Marshal.FinalReleaseComObject(cells);
