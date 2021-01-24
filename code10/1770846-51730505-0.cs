        namespace BusinessLayer.BusinessLogic.UI
        {
            [TestFixture]
            public class nunitlayer : BaseLayer
            {
                [Parallelizable]
                [Test]
                public static void test1(IWebDriver driver, WebDriverWait wait, int urlTypeId)
                {
                    LoginLayer.LoginTest(driver, wait, urlTypeId);
                }
                [Test]
                [Parallelizable]
                public static void test2(IWebDriver driver, WebDriverWait wait, int urlTypeId)
                {
                    LoginLayer.ArmenianLoginTest(driver, wait, urlTypeId);
                }
            }
         }
