    class Worker
    {
     //...
        Thread thread;
        
        public void StartWork()
        {
            thread = new Thread(Work) { Name = "Worker Thread" };
            thread.Start();
        }
    
       void WaitCompletion()
       {
         if ( thread != null ) thread.Join(); 
       }
     //...
    }
    [TestFixture]
    class WorkerTests
    {
        [Test]
        public void DoWork_WhenDone_EventIsRaised()
        {
            var worker = new Worker();
    
            var eventWasRaised = false;
            worker.Done += (s, e) => eventWasRaised = true;
    
            worker.Work();
            worker.WaitCompletion();
            Assert.That(eventWasRaised);
        }
    }
