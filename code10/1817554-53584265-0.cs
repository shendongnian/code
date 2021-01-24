    var xlApp = new Excel.Application { Visible = true };
    var xlBook = xlApp.Workbooks.Open(@"C:\Temp\Results.xlsx");
    var xlSheet = xlBook.Sheets[1] as Excel.Worksheet;
    var arr = (object[,])xlSheet.Range["B2:B100000"].Value;
    var sb = new StringBuilder();
    for (int x = 1; x <= arr.GetUpperBound(0); ++x)
    {
    	sb.Append(arr[x, 1]);
    }
    var final_string = sb.ToString();
    // Close workbook, close Excel...
