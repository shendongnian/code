    public bool ThreadSafeBusy
    {
        get { return (Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 1) == 1); }
        set
        {
            if (value) Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 0);
            else Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 0, 1);
        }
    }
    public async void Button_Click(object sender, EventArgs e)
    {
        if (!ThreadSafeBusy)
        {
            ThreadSafeBusy = true;
            await DoMyWorkAsync();
            ThreadSafeBusy = false;
        }
    }
    private async Task DoMyWorkAsync()
    {
        await Task.Run(() =>
        {
            jobs = new int[] { 0, 20, 10, 13, 12 };
            Parallel.ForEach(jobs, job_i =>
            {
                DoSomething(job_i);
                done.Enqueue(job_i);
            });
        });
    }
