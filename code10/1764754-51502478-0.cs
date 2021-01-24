    public static IWebElement RetrieveObject(IWebDriver driver, string page, string pageObject)
    {
        int rCnt = 0;
        string TablePath      = "C:\\Automation Projects\\Tables\\";
        string ObjectRepPath  = TablePath + "ObjectRepository.xlsx";
        string objpage        = " ";
        string objelement     = " ";
        string objelementType = " ";
        string objlocator     = " ";
        IWebElement locator = null;
        Application xlApp;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;
        Range range;
        xlApp       = new Application();
        xlWorkBook  = xlApp.Workbooks.Open(ObjectRepPath);
        xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
        range = xlWorkSheet.UsedRange;
        for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
        {
                    objpage        = (string)(range.Cells[rCnt, 1] as Range).Value2;
                    objelement     = (string)(range.Cells[rCnt, 2] as Range).Value2;
                    objelementType = (string)(range.Cells[rCnt, 3] as Range).Value2;
                    objlocator     = (string)(range.Cells[rCnt, 4] as Range).Value2;
            if (objpage == page && objelement == pageObject)
            {
                if (objelementType == "id")
                {
                    locator = driver.FindElement(By.Id(objlocator));
                    return locator;
                }
                else if (objelementType == "name")
                {
                    locator = driver.FindElement(By.Name(objlocator));
                    return locator;
                }
                else if (objelementType == "xpath")
                {
                    locator = driver.FindElement(By.XPath(objlocator));
                    return locator;
                }
                else
                {
                    return locator;
                }
            }
        }
        return null; // <---------------- !!
    }
