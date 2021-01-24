    void Main()
    {
    	var scheduler = new TestScheduler();
    	
    	var foo = Observable.Create<int>(async (observer, cancellationToken) => {
    		while(!cancellationToken.IsCancellationRequested){
    			var ret = await DoStuff(scheduler);
    			observer.OnNext(ret);
    			await Observable.Delay(
    				Observable.Return(Unit.Default), 
    				TimeSpan.FromSeconds(5), 
    				scheduler)
    			.ToTask();
    		}
    	});
    	
    	using(foo.Timestamp(scheduler).Subscribe(f => Console.WriteLine(f.Timestamp))){
    		scheduler.AdvanceBy(TimeSpan.FromSeconds(120).Ticks);
    	}
    	
    }
    
    // Define other methods and classes here
    
    
    public Task<int> DoStuff(IScheduler scheduler){
    	return Observable.Delay(Observable.Return(1), TimeSpan.FromSeconds(1), scheduler).ToTask();
    }
