    Microsoft.Office.Interop.Excel.ApplicationClass _excel;
    Microsoft.Office.Interop.Excel.Workbook _workBook;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        _excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        _excel.Visible = true;
    
        // Open the workbook
        _workBook = _excel.Workbooks.Open(@"DataSheet.xls",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
    
    }
    
    private void btn_Close_Click(object sender, EventArgs e)
    {
       
        GC.Collect();
        GC.WaitForPendingFinalizers();
    
        _workBook.Close(false, Type.Missing, Type.Missing);
        _excel.Quit();
    
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_workBook);
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_excel);
    
    }
