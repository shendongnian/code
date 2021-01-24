    [TestClass]
    class MyTests
    {
        [TestFixture]
        public void ThisIsATest()
        {
        }
        [BeforeAllTests]
        public void OncePerClass()
        {
        }
   
        [BeforeEachTest]
        public void OncePerTest()
        {
        }
        
        [AfterEachTest]
        public void AfterEachTest()
        {
        }
        [AfterAllTests]
        public void AfterAllTests()
        {
        }
     }
