    public class TestClass
    {
        public bool eventCanBeCreated = true;
        [TestMethod]
        public void CreateEvent()
        {         
            // Your code
            // Before Assert.Fail():
            eventCanBeCreated = false;
        }
        [TestMethod]
        public void DeleteEvent()
        {
            if (!eventCanBeCreated)
                Assert.Inconclusive("The dependent test " + testName + "failed.  Skipping this test");
            
            // Your code
        }
    }
