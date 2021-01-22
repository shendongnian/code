    class Worker
    {
        public event EventHandler<EventArgs> Done = (s, e) => { };
    
        public void StartWork()
        {
            var thread = CreateThread();
            thread.Start();
        }
    
        // Seam for extension and testability
        virtual protected Thread CreateThread()
        {
            return new Thread(Work) { Name = "Worker Thread" };
        }
    
        private void Work()
        {
            // Do some heavy lifting
            Thread.Sleep(500);
            Done(this, EventArgs.Empty);
        }
    }
    
    class WorkerForTest : Worker
    {
        internal Thread thread;
    
        protected override Thread CreateThread()
        {
            thread = base.CreateThread();
            return thread;
        }
    }
    
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
