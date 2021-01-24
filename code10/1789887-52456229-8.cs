    using System.Threading;
    // default is false, set 1 for true.
    private int _threadSafeBoolBackValue = 0;
    public bool ThreadSafeBusy
    {
        get { return (Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 1) == 1); }
        set
        {
            if (value) Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 0);
            else Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 0, 1);
        }
    }
    async void Button_Click()
    {
        if (!ThreadSafeBusy)
        {
            ThreadSafeBusy = true;
            await DoMyWorkAsync();
            ThreadSafeBusy = false;
        }
    }
    private Task DoMyWorkAsync()
    {
        jobs = new int[] { 0, 20, 10, 13, 12 };
        Parallel.ForEach(jobs, job_i =>
        {
            DoSomething(job_i);
            done.Enqueue(job_i);
        });
        return Task.CompletedTask;
    }
