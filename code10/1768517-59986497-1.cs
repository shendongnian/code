JobStorage.Current.GetConnection().GetRecurringJobs().ForEach(xx => RecurringJob.RemoveIfExists(xx.Id));
**TL;DR**
**Old Code:**
private void RemoveAllHangfireJobs()
    {
        var hangfireMonitor = JobStorage.Current.GetMonitoringApi();
        //RecurringJobs
        JobStorage.Current.GetConnection().GetRecurringJobs().ForEach(xx => BackgroundJob.Delete(xx.Id));
        //ProcessingJobs
        hangfireMonitor.ProcessingJobs(0, int.MaxValue).ForEach(xx => BackgroundJob.Delete(xx.Key));
        //ScheduledJobs
        hangfireMonitor.ScheduledJobs(0, int.MaxValue).ForEach(xx => BackgroundJob.Delete(xx.Key));
        //EnqueuedJobs
        hangfireMonitor.Queues().ToList().ForEach(xx => hangfireMonitor.EnqueuedJobs(xx.Name,0, int.MaxValue).ForEach(x => BackgroundJob.Delete(x.Key)));
    }
**New Code:**
private void RemoveAllHangfireJobs()
    {
        var hangfireMonitor = JobStorage.Current.GetMonitoringApi();
        //RecurringJobs
        JobStorage.Current.GetConnection().GetRecurringJobs().ForEach(xx => RecurringJob.RemoveIfExists(xx.Id)); // this line changed!
        //ProcessingJobs
        hangfireMonitor.ProcessingJobs(0, int.MaxValue).ForEach(xx => BackgroundJob.Delete(xx.Key));
        //ScheduledJobs
        hangfireMonitor.ScheduledJobs(0, int.MaxValue).ForEach(xx => BackgroundJob.Delete(xx.Key));
        //EnqueuedJobs
        hangfireMonitor.Queues().ToList().ForEach(xx => hangfireMonitor.EnqueuedJobs(xx.Name,0, int.MaxValue).ForEach(x => BackgroundJob.Delete(x.Key)));
    }
PS Edit:
My Hangfire version is 1.7.9
and using Hangfire.PostgreSql
  [1]: https://stackoverflow.com/users/4268340/pieter-alberts
