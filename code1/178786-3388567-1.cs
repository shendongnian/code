    public void AddJob(string jobName) { ... }
    public void AddJob2(string jobName) { ... }
    public void RunAddJob(Action addJob)
    {
        ...
        addJob();
    }
    static void Main()
    {
        RunAddJob(() => AddJob("job1"));
        RunAddJob(() => AddJob2("job2"));
    }
