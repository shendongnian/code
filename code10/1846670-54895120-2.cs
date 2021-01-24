	object pJobLock = new object();
    int numProcessed = 0;
	foreach(var parallelJob in parallelJobs)
	{
        parallelJob.DoWork();
        lock (pJobLock)
        {
            numProcessed++;
            progress.Report(new MyCustomProgress { Current = numProcessed, Total = parallelJobs.Count() });
        }
	}
