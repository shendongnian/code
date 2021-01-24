    using System.Diagnostics;
    using Excel = Microsoft.Office.Interop.Excel;
    private void ProcessMergedCells()
    {
    
    	var xlApp = new Excel.Application { Visible = false, ScreenUpdating = false };
    	// get Excel process in order to kill it after the work is done
    	var xlHandle = new IntPtr(xlApp.Hwnd);
    	var xlProc = Process
                     .GetProcesses()
                     .First(p => p.MainWindowHandle == xlHandle);
    	var book = xlApp.Workbooks.Open(@"C:\AutoFitMergedCells.xlsm");
    	var sheet = book.Sheets[1] as Excel.Worksheet;
    
    	// obtain merged cells any way you like
    	// here I just populate array with arbitrary cells
    	var merged_ranges = new Excel.Range[]
    	{
    		sheet.Range["D11"],
    		sheet.Range["D13"]
    	};
    
    	// process merged cells
    	foreach(var merged_range in merged_ranges)
    	{
    		AutoFitMergedCells(merged_range);
    	}
    
    	// quit with saving
    	book.Close(SaveChanges: true);
    	xlApp.Quit();
    
    	// clean up
    	GC.Collect();
    	GC.WaitForFullGCComplete();
    
    	// kill Excel for sure
    	xlProc.Kill();
    
    }
    
    private void AutoFitMergedCells(Excel.Range merged_range)
    {
    
    	double dOldHeight = 0d, dNewHeight = 0d;
    	var dicCells = new Dictionary<string, Dictionary<string, double>>();
    
    	// remember rows count for merging cells back
    	int rows_count = merged_range.MergeArea.Count;
    
    	// every dictionary entry holds following info:
    	// 1) original height of all rows in merged cells
    	// 2) percentage of row's height to height of all rows in merged area
    	foreach (Excel.Range the_row in merged_range.MergeArea.Rows)
    	{
    		// we need only top-left cell
    		var first_cell = the_row.Cells[1];
    		var dicHeights = new Dictionary<string, double>
    		{
    			["height"] = first_cell.RowHeight,
    			["percent"] = 0d
    		};
    		dicCells[first_cell.Address[0, 0]] = dicHeights;
    	}
    
    	// total height of all rows
    	foreach (string addr in dicCells.Keys)
    		dOldHeight += dicCells[addr]["height"];
    
    	// update the percentage of every row
    	foreach (string addr in dicCells.Keys)
    		dicCells[addr]["percent"] = dicCells[addr]["height"] / dOldHeight;
    
    	// unmerge range and autofit
    	merged_range.UnMerge();
    	merged_range.EntireRow.AutoFit();
    
    	// remember new height
    	dNewHeight = merged_range.RowHeight;
    
    	// this applies percentage of previous row's height to new height
    	var sheet = merged_range.Parent;
    	foreach (string addr in dicCells.Keys)
    		sheet.Range[addr].EntireRow.RowHeight = dicCells[addr]["percent"] * dNewHeight;
    
    	// merge back
    	merged_range.Resize[rows_count].Merge();
    
    }
