    [Test]
     public void DoWork_WhenDone_EventIsRaised()
     {
      var worker = new Worker();
    
      var eventWasRaised = false;
      var mre = new ManualResetEvent();
      worker.Done += (s, e) => { eventWasRaised= true; mre.Set(); }
      
      worker.Work();
      mre.WaitOne(1000);
      Assert.That(eventWasRaised);
     }
