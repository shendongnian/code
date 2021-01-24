    [TestClass]
    public class UnitTest1  : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Page1().method1();
            new Page2().method2();
            Driver.Testcleanup();
        }
        [TestMethod]
        public void TestMethod2()
        {
            new Page1().method1();
            new Page2().method2();
            Driver.Testcleanup();
        }
       
        public class Page1 
        {
            public void method1()
            {
                Driver.Instance.Navigate().GoToUrl("http://www.google.com");
            }
        }
        public class Page2 
        {
            public void method2()
            {
                Driver.Instance.Navigate().GoToUrl("http://www.google.com");
            }
        }
    }
