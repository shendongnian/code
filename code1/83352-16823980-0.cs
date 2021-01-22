    Action work = () => Console.WriteLine(DateTime.Now.ToLongTimeString());
    
    Scheduler.Default.Schedule(
        // start in so many seconds
        TimeSpan.FromSeconds(60 - DateTime.Now.Second), 
        // then run every minute
        () => Scheduler.Default.SchedulePeriodic(TimeSpan.FromMinutes(1), work));				
		
	Console.WriteLine("Press return.");
	Console.ReadLine();
