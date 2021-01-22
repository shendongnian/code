    using Quartz;
    using Quartz.Impl;
    
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            // get a scheduler
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();
            // construct job info
            JobDetail jobDetail = new JobDetail("mySendMailJob", typeof(SendMailJob));
            // fire every day at 06:00
            Trigger trigger = TriggerUtils.MakeDailyTrigger(06, 00);
            trigger.Name = "mySendMailTrigger";
            // schedule the job for execution
            sched.ScheduleJob(jobDetail, trigger);
        }
        ...
    }
