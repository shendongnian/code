    Excel.Application excelApp = ...;
    
    string prompt = "Please select the range.";
    string title = "Input Range";
    int returnDataType = 8;
    String DefaultRange = oXL.Selection.Address();
    Excel.Range myRange = excelApp.InputBox(
                              prompt,
                              title,
                              DefaultRange,
                              Type.Missing,
                              Type.Missing,
                              Type.Missing,
                              Type.Missing,
                              returnDataType)
