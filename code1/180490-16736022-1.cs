    TimeSpan interval = TimeSpan.FromSeconds(5);
    Action work = () => Console.WriteLine("Doing some work...");
    var schedule = Scheduler.Default.ScheduleRecurringAction(interval, work);          
    Console.WriteLine("Press return to stop.");
    Console.ReadLine();
    schedule.Dispose();
