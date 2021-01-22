    Excel.Application app = new Excel.Application();
    
    Excel.Workbook wbook = null;
    
    Excel.Worksheet wsheet = null;
    
    Excel.Range range = null;
    
    app.Visible = false;
    
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
    string filepath = inputFile1.Value.ToString();
    
    if (filepath != "")
    
    {
    
    wbook = app.Workbooks.Open(filepath, Missing.Value, Missing.Value, Missing.Value,
    
    Missing.Value, Missing.Value, Missing.Value,
    
    Missing.Value, Missing.Value, Missing.Value,
    
    Missing.Value, Missing.Value, Missing.Value,
    
    Missing.Value, Missing.Value);
    
     
    
    string currentSheet = "Sheet1";
    
    wsheet = (Excel.Worksheet)wbook.Worksheets.get_Item(currentSheet);
    
    range = wsheet.get_Range("B6", "H20");
    
    System.Array myvalues = (System.Array)range.Cells.Value2;
    
    valueArray = ConvertToStringArray(myvalues);
    
     
    
    if (app != null)
    
    {
    
    app.Workbooks.Close();
    
    app.Quit();
    
    }
    
    app = null;
    
    wsheet = null;
    
    range = null;
    string[] ConvertToStringArray(System.Array values)
    { 
    
    // create a new string array
    string[] theArray = new string[values.Length];
    
    // loop through the 2-D System.Array and populate the 1-D String Array
     for (int i = 1; i <= values.Length; i++)
      {
       if (values.GetValue(1, i) == null)
        theArray[i-1] = "";
      else
       theArray[i-1] = (string)values.GetValue(1, i).ToString();
      }
    
      return theArray;
    }
