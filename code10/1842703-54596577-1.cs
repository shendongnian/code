    string file = @"C:\Users\me\Desktop\Summary.xlsx";
    List<string> fileData = new List<string>{@"C:\Users\me\Desktop\Book1.xlsx", 
                                             @"C:\Users\me\Desktop\Book2.xlsx"};      
    Excel.Application xlApp = new Excel.Application();
      
    // Open summary workbook and init data workbook and worksheet
    Excel.Workbook xlWb = xlApp.Workbooks.Open(file);
    Excel.Worksheet xlWsSummary = xlWb.Sheets[1];
    Excel.Workbook xlWbData = null;
    Excel.Worksheet xlWsData = null;
    // Work through your data workbooks
    for ( int i = 0; i < fileData.Count; i++ )
    {
        // Open data workbook
        xlWbData = xlApp.Workbooks.Open(fileData[i]);
        xlWsData = xlWbData.Sheets[1];
        // Get specific range of data. I didn't use UsedRange in case only a subset of data is required
        string dataStart = "A1";
        string dataEnd = "C2";
        Excel.Range rangeSource = xlWsData.get_Range(dataStart, dataEnd);
        // Determine next available 'A' cell after used range in summary worksheet
        Excel.Range ra = xlWsSummary.UsedRange;
        Excel.Range rangeDest = ra.get_Range("A" + (ra.Rows.Count + 1));
        // Copy data from data workbook to summary workbook
        rangeSource.Copy(rangeDest);
        // Select the range just copied to the summary workbook and format as required
        Excel.Range rangeFormat = rangeDest.Resize[rangeSource.Rows.Count, rangeSource.Columns.Count];
        rangeFormat.Font.Size = 8;//set the fontsize ```
    }
    // Release data workbook objects and close before doing anything else
    Marshal.ReleaseComObject(xlWsData);
    xlWbData.Close();
    Marshal.ReleaseComObject(xlWbData);
    // Select next available cell in A column
    xlWsSummary.Activate();
    Excel.Range used = xlWsSummary.UsedRange;
    Excel.Range next = xlWsSummary.get_Range("A" + (used.Rows.Count + 1));
    next.Select();
      
    // Save the file
    xlWb.SaveAs(file);
    // And, release!
    Marshal.ReleaseComObject(xlWsSummary);
    xlWb.Close();
    Marshal.ReleaseComObject(xlWb);
