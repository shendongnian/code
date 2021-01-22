    private static bool IsStockDataWorkbook(string fileName)
    {
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        try
        {
            application = new Excel.ApplicationClass();
            application.Visible = true;
            workbook = application.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    
            foreach (Excel.Worksheet sheet in workbook.Worksheets)
            {
                if (IsStockWorksheet(sheet))
                {
                    return true;
                }
            }
    
            return false;
        }
        finally
        {
            if (workbook != null)
            {
                workbook.Close(false, Missing.Value, Missing.Value);
            }
            if (application != null)
            {
                application.Quit();
            }
        }
    }
    private static bool IsStockWorksheet(Excel.Worksheet workSheet)
    {
        Excel.Range testRange = workSheet.get_Range("C10", Missing.Value);
        string value = testRange.get_Value(Missing.Value).ToString();
    
        return value.Equals("close", StringComparison.InvariantCultureIgnoreCase);
    }
    
