    [TestFixture]
    public class SmokeTests
    {
        private Application _theApp;
        private UIA3Automation _automation;
        private Window _mainWindow;
        private const int BigWaitTimeout = 3000;
        private const int SmallWaitTimeout = 1000;
        [SetUp]
        public void Setup()
        {
            _theApp = FlaUI.Core.Application.Launch(new ProcessStartInfo("YOUR_APPLICATION.exe", "/quickStart"));
            _automation = new UIA3Automation();
            _mainWindow = _theApp.GetMainWindow(_automation);
        }
        [TearDown]
        public void Teardown()
        {
            _automation?.Dispose();
            _theApp?.Close();
        }
        [Test]
        public void Foo()
        {
            // This will wait until the element is available, or timeout passed
            var examplesWrapPanel = WaitForElement(() => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ExamplesWrapPanel")));
            // This will wait for the child element or timeout 
            var exampleButton = WaitForElement(() => examplesWrapPanel?.FindFirstDescendant(cf => cf.ByAutomationId("Another Automation Id")).AsButton());
  
            // Do something with your elements 
            exampleButton?.WaitUntilClickable();
            exampleButton?.Invoke();
        }
        private T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
                () => getter(),
                TimeSpan.FromMilliseconds(BigWaitTimeout));
            if (!retry.Success)
            {
                Assert.Fail("Failed to get an element within a wait timeout");
            }
            return retry.Result;
        }
    }
