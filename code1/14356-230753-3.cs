    private object m_LockerA = new object();
    private object m_LockerB = new object();
    lock (m_LockerA)
    {
        // It's possible this block is active in one thread
        // while the block below is active in another
        // Do something with the dictionary
    }
    lock (m_LockerB)
    {
        // It's possible this block is active in one thread
        // while the block above is active in another
        // Do something with the dictionary
    }
