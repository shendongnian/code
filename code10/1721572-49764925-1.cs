          [TestFixture]
    class TC_1
    {
  
      public static IEnumerable<TestCaseData> BudgetData
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(//path//document.xlsx",
                    "SheetName");
                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
        [Test]     
        [TestCaseSource(typeof(TC_1), "BudgetData")]
        public void TestCase1(string attribbutte1, string .....)
        {
         ........................................
