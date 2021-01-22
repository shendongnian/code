    string SleepAndWakeUp(string value,CancellationToken ct)
    {
        ct.WaitHandle.WaitOne(60000);
        return value;
    }
    void Parent()
    {
         CancellationTokenSource cts = new CancellationTokenSource();
         Task.Run(() => SleepAndWakeUp("Hello World!", cts.Token), cts.Token);
         //Do some other work here
         cts.Cancel(); //Wake up the asynch task
    }
