    var backgroundJob = performContext.BackgroundJob;
    var monitoringApi = JobStorage.Current.GetMonitoringApi();
    var succeededCount = (int)monitoringApi.SucceededListCount();
    if (succeededCount > 0) 
    {
        var queryCount = Math.Min(succeededCount, 1000);
        // read up to 1000 latest succeeded jobs:
        var succeededJobs = monitoringApi.SucceededJobs(succeededCount - queryCount, queryCount);
        // check if job with the same ID already finished:
        if (succeededJobs.Any(succeededKp => backgroundJob.Id == succeededKp.Key)) 
        {
            // The job was already started and succeeded, skip this execution
            return;
        }
    }
