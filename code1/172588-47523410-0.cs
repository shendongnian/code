    void ScheduleSomething()
    {
    
        var runAt = DateTime.Today + TimeSpan.FromHours(16);
    
        if (runAt <= DateTime.Now)
        {
            DoSomething();
        }
        else
        {
            var delay = runAt - DateTime.Now;
            System.Threading.Tasks.Task.Delay(delay).ContinueWith(_ => DoSomething());
        }
    
    }
    
    void DoSomething()
    {
        // do somethig
    }
