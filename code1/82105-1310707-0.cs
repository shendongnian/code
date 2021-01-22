    private class ThreadParameters
    {
       ....
    }
    
    ...
    
    public void ThreadFunc(object state)
    {
        ThreadParameters params = (ThreadParameters)state;
        ....
    }
    
    Thread t = new Thread(new ParameterizedThreadStart(ThreadFunc));
    t.Start(new ThreadParameters() { ... });
