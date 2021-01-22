    Excel.Application excelApp = ...;
    
    string prompt = "Please select the range.";
    string title = "Input Range";
    int returnDataType = 8;
    
    Excel.Range myRange;
    myRange = excelApp.InputBox(
                    prompt,
                    title,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    returnDataType)
