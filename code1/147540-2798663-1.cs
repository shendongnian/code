    [NUnitAddin]
    public class NUnitAssertionHandler : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            Debug.Listeners.Clear();
            Debug.Listeners.Add(new AssertFailTraceListener());
            return true;
        }
        private class AssertFailTraceListener : DefaultTraceListener
        {
            public override void Fail(string message, string detailMessage)
            {
                Assert.Fail("Assertion failure: " + message);
            }
            public override void Fail(string message)
            {
                Assert.Fail("Assertion failure: " + message);
            }
        }
    }
