    private readonly object m_lock = new object();
    public void RunSynchronous()
    {
        lock(m_lock) {
            CallAsynchronousMethod();
            Monitor.Wait(m_lock);
        }
    }
    private void Callback()
    {
        lock(m_lock)
            Monitor.Pulse(m_lock);
    }
