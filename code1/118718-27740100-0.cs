    [Test]
    public void TwoCodeBlocksInParallelTest()
    {
    	// This static method runs the provided Action delegates in parallel using threads
    	CTestHelper.Run(
    		c =>
    			{
    				Thread.Sleep(1000); // Here should be the code to provide something 
    				CTestHelper.AddSequenceStep("Provide"); // We record a sequence step for the expectations after the test
    				CTestHelper.SetEvent();
    			},
    		c =>
    			{
    				CTestHelper.WaitEvent(); // We wait until we can consume what is provided
    				CTestHelper.AddSequenceStep("Consume"); // We record a sequence step for the expectations after the test
    			},
    		TimeSpan.FromSeconds(10)); // This is a timeout parameter, if the threads are deadlocked or take too long, the threads are terminated and a timeout exception is thrown 
    
    	// After Run() completes we can analyze if the recorded sequence steps are in the correct order
    	Expect(CTestHelper.GetSequence(), Is.EqualTo(new[] { "Provide", "Consume" }));
    }
