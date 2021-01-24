    using NUnit.Framework;
    namespace AutomationTest 
    {
    class TestHelper
    {
        //protected IWebDriver driver;
        protected void Browse(Action<IWebDriver> action)
        {
          var driver = new ChromeDriver("C:\\Users\\james\\Desktop");
          action(driver);
          driver.Close();
          driver.Quit();
        }
        [SetUp]
        public void startBrowser()
        {
            // driver = new ChromeDriver("C:\\Users\\james\\Desktop");
        }
        
        [TearDown]
        public void closeBrowser()
        {
            // driver.Close();
            // driver.Quit();
        }
    }
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class ParallelTest : TestHelper
    {
        [Test]
        public void test1()
        {   
            Browse( (driver) => {         
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test2()
        {   
            Browse( (driver) => {                  
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test3()
        {     
            Browse( (driver) => {                
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test4()
        {     
            Browse( (driver) => {                
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test5()
        {       
            Browse( (driver) => {              
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test6()
        {     
            Browse( (driver) => {               
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        } 
        [Test]
        public void test7()
        {     
            Browse( (driver) => {                
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");
            });
        }
        [Test]
        public void test8()
        {     
            Browse( (driver) => {                
              driver.Navigate().GoToUrl("http://www.google.com");
              Assert.AreEqual(driver.Title, "Google", "Stuff didn't work");   
            });
        }
    }
    }
