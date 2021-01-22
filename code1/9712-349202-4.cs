    using (AutoReleaseComObject<Application> excelApplicationWrapper = new AutoReleaseComObject<Application>(new Application()))
    {
        try
        {
            using (AutoReleaseComObject<Workbook> workbookWrapper = new AutoReleaseComObject<Workbook>(excelApplicationWrapper.ComObject.Workbooks.Open(namedRangeBase.FullName, false, false, missing, missing, missing, true, missing, missing, true, missing, missing, missing, missing, missing)))
            {
               // do something with your workbook....
            }
        }
        finally
        {
             excelApplicationWrapper.ComObject.Quit();
        } 
    }
