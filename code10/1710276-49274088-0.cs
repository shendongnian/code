    public static Boolean GetCurrentFinancialYear(DateTime CompareDate)
    {
        Boolean DeleteRecord = false;
        var CurrentEndDate = new DateTime(DateTime.Now.Year, 7, 1);
        var CurrentStartDate = new DateTime(DateTime.Now.Year - 1, 6, 30);
        if (CompareDate >= CurrentStartDate && CompareDate < CurrentEndDate)
        {
            DeleteRecord = false;
        }
        else
        {
            DeleteRecord = true;
        }      
        return DeleteRecord;
    }
