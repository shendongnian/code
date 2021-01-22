    bool shouldGoAway = false;
    public void AddThread(Thread t)
    {
        lock (_sync)
        {
            if( ! shouldGoAway )
                _threads.Add(t);
        }
    }
    public void Shutdown()
    {
        lock (_sync)
        {
            shouldGoAway = true;
            foreach (Thread t in _threads)
            {
                t.Abort(); // does this also abort threads that are currently blocking?
            }
        }
 
