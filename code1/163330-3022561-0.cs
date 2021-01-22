    try
    {
        Excel.Range rngTemp;
        Excel.Range rngErrorRange;
    
        Excel._Worksheet Sheet1 = (Excel._Worksheet)xlCTA.Sheets["Sheet1"];
        rngTemp = wsCTAWK11.UsedRange;
        rngErrorRange = rngTemp.SpecialCells(Excel.XlCellType.xlCellTypeFormulas,
    Excel.XlSpecialCellsValue.xlErrors);
    }
    catch (System.Runtime.InteropServices.COMException ex)
    {
        //Handle here
    }
