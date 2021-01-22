     using Excel = Microsoft.Office.Interop.Excel;
     ...
     object mis = Type.Missing;
     Excel.FormatCondition cond =
        (Excel.FormatCondition)range.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue,
        Excel.XlFormatConditionOperator.xlEqual, "=1",
        mis, mis, mis, mis, mis);
        cond.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
        cond.Interior.TintAndShade = 0;
        cond.Interior.Color = ColorTranslator.ToWin32(Color.White);
        cond.StopIfTrue = false;
