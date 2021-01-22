    // Unhide All Cells and clear formats
    sheet.Columns.ClearFormats();
    sheet.Rows.ClearFormats();
    // Detect Last used Row - Ignore cells that contains formulas that result in blank values
    int lastRowIgnoreFormulas = sheet.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value,
                    InteropExcel.XlFindLookIn.xlValues,
                    InteropExcel.XlLookAt.xlWhole,
                    InteropExcel.XlSearchOrder.xlByRows,
                    InteropExcel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value).Row;
    // Detect Last Used Column  - Ignore cells that contains formulas that result in blank values
    int lastColIgnoreFormulas = sheet.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    InteropExcel.XlSearchOrder.xlByColumns,
                    InteropExcel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value).Column;
    // Detect Last used Row / Column - Including cells that contains formulas that result in blank values
    int lastColIncludeFormulas = sheet.UsedRange.Columns.Count;
    int lastColIncludeFormulas = sheet.UsedRange.Rows.Count;
