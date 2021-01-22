    namespace Tests
    {
	    [TestFixture]
	    public class Test1 : Test
	    {
	        public Test1(string browser)
	        {
		        SetBrowser(browser);
	        }
	        [Test]
	        public void FirstTest()
	        {
		        ...
	        }
	   }
    }
