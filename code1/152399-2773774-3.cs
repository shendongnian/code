    public static bool ContainsWorkbookProperly(this Excel.Workbooks excelWbs,
        string sWorkbookName)
    {
        Excel.Workbook wbTemp = null;
        try
            wbTemp = excelWbs.Item(sWorkbookName);
        catch (Exception)
        {
            // ignore
        }
        if (wbTemp != null)
        {
            new DisposableCom<Excel.Workbook>(wbTemp).Dispose();
            return true;
        }
        return false;
    }
