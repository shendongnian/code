    [TestFixture]
    public class ClassWithDataLoad
    {
        private bool loadFailed;
    
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            // Assuming loading failure throws exception.
            // If not if-else can be used.
            try 
            {
                // Try load data
            }
            catch (Exception)
            {
                loadFailed = true;
            }
        }
    
        [SetUp]
        public void Setup()
        {
            if (loadFailed)
            {
                Assert.Inconclusive();
            }
        }
    
        [Test]
        public void Test1() { }
        
        [Test]
        public void Test2() { }
    }
