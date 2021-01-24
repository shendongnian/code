    Please Change last line of your code (PasteSpecial) and try below code.
    please use Row and column variables as per your code.
    Microsoft.Office.Interop.Excel.Range PastToRange =
    oExcel.CreateRange(row,FromCol,ToCol,ToRow,TmpWorkSheet);
    PastToRange.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteAll,
    Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone,
    false, false);
