    public void AddJob(string jobName) { ... }
    public void AddJob2(string jobName) { ... }
    public void RunAddJob<T>(T jobName, Action<T> addJob)
    {
        ...
        addJob(jobName);
    }
    static void Main()
    {
        RunAddJob("job1", AddJob);
        RunAddJob("job2", AddJob2);
    }
