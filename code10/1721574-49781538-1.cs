    namespace Automation
        {
        [TestFixture]
        class Excel_TC_1 
            {
            private readonly string testCaseData;
            public static IEnumerable<TestCaseData> BudgetData
                {
                get
                    {
                    List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(@"C:\Safety_dan\AutomationTest\TestData\test.xlsx",
                        "Sheet1");
                    if (testCaseDataList != null)
                        foreach (TestCaseData testCaseData in testCaseDataList)
                            yield return testCaseData;
                    }
                }
            [Test]
            [TestCaseSource(typeof(Excel_TC_1), "BudgetData")]
            public void TestCase1(string attribbutte1)
                {
                // Login
                CcLoginPageObject ccPageLogin = new CcLoginPageObject();
                ClientLoginPageObject clientLoginPage = new ClientLoginPageObject();
                    ccPageLogin.Login("username", "password");
              
                // Loading client code:
                Driver.FindElement(By.Id("ClientsSearch")).SendKeys(testCaseData);
                }
            }
            }
