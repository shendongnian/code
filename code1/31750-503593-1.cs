    // Instantiate the Quartz.NET scheduler
    var schedulerFactory = new StdSchedulerFactory();
    var scheduler = schedulerFactory.GetScheduler();
    // Instantiate the JobDetail object passing in the type of your
    // custom job class. Your class merely needs to implement a simple
    // interface with a single method called "Execute".
    var job = new JobDetail("job1", "group1", typeof(MyJobClass));
    
    // Instantiate a trigger using the basic cron syntax.
    // This tells it to run at 1AM every Monday - Friday.
    var trigger = new CronTrigger(
    	"trigger1", "group1", "job1", "group1", "0 0 1 ? * MON-FRI");
    
    // Add the job to the scheduler
    scheduler.AddJob(job, true);
    scheduler.ScheduleJob(trigger);
