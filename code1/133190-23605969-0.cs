    public static bool IsSheetEmpty(int sheetNo)
    {
        bool isEmpty = false;
    
        if (sheetNo <= Globals.ThisAddIn.Application.Worksheets.Count)
        {
            Worksheet ws = Globals.ThisAddIn.Application.Worksheets[sheetNo];
    
            if (ws.UsedRange.Address.ToString() == "$A$1" && String.IsNullOrWhiteSpace(ws.get_Range("A1").Value2))
            {
                isEmpty = true;
            }
        }
        else
        {
            // or add your own error handling when sheetNo is not found
        }
                            
        return isEmpty;
    }
