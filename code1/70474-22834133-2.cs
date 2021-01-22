    [TestClass]
    public class ApplicationInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var waitForApplicationRun = new ManualResetEventSlim();
            Task.Run(() =>
            {
                var application = new Application();
                application.Startup += (s, e) => { waitForApplicationRun.Set(); };
                application.Run();
            });
            waitForApplicationRun.Wait();
        }
    }
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            // implementation can access Application.Current.Dispatcher
        }
    }
