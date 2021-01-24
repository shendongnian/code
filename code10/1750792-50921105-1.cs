    public void DeleteRunningHangfireJob(string methodName)
        {
            if (!string.IsNullOrEmpty(methodName)) {
                var monitor = JobStorage.Current.GetMonitoringApi();
                var processingJobs = monitor.ProcessingJobs(0, int.MaxValue);
                var enqueuedJobs = monitor.EnqueuedJobs(0, int.MaxValue);
                processingJobs.Where(o => o.Value.Job.Method.Name == methodName).ToList().ForEach(x => { BackgroundJob.Delete(x.Key); });
                enqueuedJobs.Where(o => o.Value.Job.Method.Name == methodName).ToList().ForEach(x => { BackgroundJob.Delete(x.Key); });
            }
        }
