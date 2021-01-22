    object oOpt = System.Reflection.Missing.Value; //for optional arguments
    Excel.Application oXL = new Excel.Application();
    Excel.Workbooks oWBs = oXL.Workbooks;
    Excel.Workbook oWB = oWBs.Add(Excel.XlWBATemplate.xlWBATWorksheet);
    Excel.Worksheet oSheet = (Excel.Worksheet)oWB.ActiveSheet;
    
    //outputRows is a List<List<object>>
    int numberOfRows = outputRows.Count;
    int numberOfColumns = outputRows.Max(list => list.Count);
    
    Excel.Range oRng = 
        oSheet.get_Range("A1", oOpt)
            .get_Resize(numberOfRows, numberOfColumns);
    
    object[,] outputArray = new object[numberOfRows, numberOfColumns];
    
    for (int row = 0; row < numberOfRows; row++)
    {
        for (int col = 0; col < outputRows[row].Count; col++)
        {
            outputArray[row, col] = outputRows[row][col];
        }
    }
    
    oRng.set_Value(oOpt, outputArray);
    
    oXL.Visible = true;
