    using NUnit.Framework;
    using PNUnit.Framework;
    namespace Tests
    {
        [TestFixture]
        public class Test
        {
            private string browser;
            protected Test()
            {
            }     
        
            [SetUp]
            public virtual void Setup()
            {
                browser = PNUnitServices.Get().GetTestParams();
                Selenium = new DefaultSelenium(localhost, 5555, browser, "http://www.google.com/");
                Selenium.Start();
            }
            [TearDown]
            public virtual void TearDown()
            {
                Selenium.Stop();
            }
        }
    }
