    foreach (Excel.Workbook workbook in excelApp.Workbooks)
    {
        foreach (Excel.Worksheet worksheet in workbook.Worksheets)
        {
            worksheet.Cells.Replace(
                "MyFunction(",
                "MyFunction(",
                Excel.XlLookAt.xlPart,
                Excel.XlSearchOrder.xlByRows,
                false,
                Type.Missing,
                Type.Missing,
                Type.Missing);
        }
    }
