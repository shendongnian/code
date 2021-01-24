    public void StartJob()
    {      
      var builder = new JobInfo.Builder(1234, new ComponentName(Android.App.Application.Context, Java.Lang.Class.FromType(typeof(ScheduledJob))));
      builder.SetPeriodic(15L * 60L * 1000L); // <- change the intervall
      var jobInfo = builder.Build();
      var jobScheduler = (JobScheduler)Android.App.Application.Context.GetSystemService(Context.JobSchedulerService);
      jobScheduler.Schedule(jobInfo);
    }
   
