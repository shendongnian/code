    [TestClass]
    public class TestClass
    {
        private static Application s_Application;
    
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            s_Application = new Application();
        }
    
        [ClassCleanup]
        public static void ClassCleanup()
        {
            s_Application.Shutdown();
            s_Application = null;
        }
        [TestClass]
        public void MyTest()
        {
            // implementation can access Application.Current.Dispatcher
        }
    }
