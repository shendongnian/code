    [TestFixture]
    class WorkerTests
    {
        [Test]
        public void DoWork_WhenDone_EventIsRaised()
        {
            var worker = new WorkerForTest();
    
            var eventWasRaised = false;
            worker.Done += (s, e) => eventWasRaised = true;
    
            worker.StartWork();
            // Use the seam for synchronizing the thread in the test
            worker.thread.Join();
            Assert.That(eventWasRaised);
        }
    }
