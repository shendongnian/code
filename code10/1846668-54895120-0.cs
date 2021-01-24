    public void RunJobs(IProgress<MyCustomProgress> progress)
    {       
        _sequentialJobsToRun.ForEach(job => 
        {
            job.Execute();
            progress.Report(new MyCustomProgress { Current = _jobsToRun.IndexOf(job) + 1, Total = _jobsToRun.Count() });
        });
        Parallel.ForEach(_parallelJobsToRun, job => 
        {
            job.Execute();
            // Report progress here
        });
    }
