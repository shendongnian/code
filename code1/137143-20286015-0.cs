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
                e.Result.ShouldBeTrue();
                autoEvent.Set(); // event set
            });
            autoEvent.WaitOne(); // wait until event set
        }
    }
