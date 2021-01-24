    [Service(Exported = true, Permission = "android.permission.BIND_JOB_SERVICE")]
    public class ScheduledJob : JobService
    {
        public override bool OnStartJob(JobParameters @params)
        {
            new AlarmReceiver().GetNotification("Hello World!", "Xamarin");
            return false;
        }
        
        public override bool OnStopJob(JobParameters @params)
        {
            return false;
        }
    }
