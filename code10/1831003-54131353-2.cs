    // Passing test    
    [Test]
    public void TestSchedulerExperiment()
    {
        new TestScheduler().With(s =>
        {
            var v = false;
    
            Observable
                .Return(true)
                .Delay(TimeSpan.FromSeconds(1), s)
                .Subscribe(_ => v = true);
            s.Start();
            Console.WriteLine("Scheduler clock value: {0}", s.Clock);
    
            Assert.True(v);
        });
    }
