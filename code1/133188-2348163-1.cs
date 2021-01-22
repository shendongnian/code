    // C# 3.0 and below
    int dataCount = (int)excelApp.WorksheetFunction.CountA(
        worksheet.Cells, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    if (dataCount == 0)
    {
        // All cells on the worksheet are empty.
    }
    else
    {
        // There is at least one cell on the worksheet that has non-empty contents.
    }
