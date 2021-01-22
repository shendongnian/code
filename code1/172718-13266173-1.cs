    try {
        if (log.IsDebugEnabled) {
           log.Debug("Calling Execute on job " + jobDetail.Key);
        }
        job.Execute(jec);
        endTime = SystemTime.UtcNow();
    } catch (JobExecutionException jee) {
        endTime = SystemTime.UtcNow();
        jobExEx = jee;
        log.Info(string.Format(CultureInfo.InvariantCulture, "Job {0} threw a JobExecutionException: ", jobDetail.Key), jobExEx);
    } catch (Exception e) {
       // other stuff here...
    }
