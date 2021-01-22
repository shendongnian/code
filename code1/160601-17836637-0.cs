    public void JobWasExecuted(JobExecutionContext context,
                           JobExecutionException jobException)
    {
        var sql = @"INSERT INTO MyJobAuditHistory 
                    (JobKey, RunTime, Status, Exception) VALUES (?, ?, ?, ?)";
    
        // create command etc.
        command.Parameters.Add(context.JobDetail.Key.ToString());
        command.Parameters.Add(context.JobRunTime);
        command.Parameters.Add(jobException == null ? "Success" : "Fail");
        command.Parameters.Add(jobException == null ? null : jobException.Message);
    }
