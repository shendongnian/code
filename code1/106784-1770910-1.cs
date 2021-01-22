    [TestFixture]
    class WorkerTests
    {
        [Test]
        public void DoWork_WhenDone_EventIsRaised()
        {
            var worker = new Worker();
    
            AutoResetEvent eventWasRaised = new AutoResetEvent(false);
            worker.Done += (s, e) => eventWasRaised.Set();
    
            worker.Work();
            Assert.That(eventWasRaised.WaitOne());
        }
    }
