    private object[,] GetExcelData()
    {
        xlApp = new Excel.Application { Visible = false };
        var xlBook =
            xlApp.Workbooks.Open(System.IO.Path.Combine(
                                     Environment.CurrentDirectory,
                                     "Employees.xlsx"));
    	var xlSheet = xlBook.Sheets[1] as Excel.Worksheet;
    
    	// For process termination
    	var xlHwnd = new IntPtr(xlApp.Hwnd);
    	var xlProc = Process.GetProcesses()
                     .Where(p => p.MainWindowHandle == xlHwnd)
                     .First();
    
    	// Get Excel data: it's 2-D array with lower bounds as 1.
    	object[,] arr = xlSheet.Range["A1"].CurrentRegion.Value;
    
    	// Shutdown Excel
    	xlBook.Close();
    	xlApp.Quit();
    	xlProc.Kill();
    	GC.Collect();
    	GC.WaitForFullGCComplete();
    
    	return arr;
    }
