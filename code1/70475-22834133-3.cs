    [TestClass]
    public class ApplicationInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var waitForApplicationRun = new TaskCompletionSource<bool>()
            Task.Run(() =>
            {
                var application = new Application();
                application.Startup += (s, e) => { waitForApplicationRun.SetResult(true); };
                application.Run();
            });
            waitForApplicationRun.Task.Wait();        
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
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
