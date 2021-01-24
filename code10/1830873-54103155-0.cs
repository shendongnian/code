    [TestClass]
    public class UnitTest1  : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Page1().method1();
            new Page2().method2();
        }
        [TestMethod]
        public void TestMethod2()
        {
            new Page1().method1();
            new Page2().method2();
        }
       
        public class Page1 
        {
            public void method1()
            {
                driver.Navigate().GoToUrl("http://www.google.com");
            }
        }
        public class Page2 
        {
            public void method2()
            {
                driver.Navigate().GoToUrl("http://www.stackoverflow.com");
            }
        }
    }
