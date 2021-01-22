    public void DoSomething ()
    {
           DateTime start = DateTime.UtcNow;
           ...
           TimeSpan elapsed = (DateTime.UtcNow - start);
           int due_in = (int) (10000 - elapsed.TotalMilliseconds);
           if (due_in < 0)
               due_in = 0;
           timer.Change (due_in, Timeout.Infinite);
    }
