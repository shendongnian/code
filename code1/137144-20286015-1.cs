    [TestFixture]
    class SomeTests
    {
        [Test]
        public void AsyncTest()
        {
            var autoEvent = new AutoResetEvent(false); // initialize to false
            var Some = new Some();
            Some.AsyncFunction(e =>
            {
                Assert.True(e.Result);
                autoEvent.Set(); // event set
            });
            autoEvent.WaitOne(); // wait until event set
        }
    }
