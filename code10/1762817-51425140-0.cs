    public bool Running
    {
        get { lock (runningLock) { return mRunning; } }
        set
        {
            lock (runningLock)
            {
                RunningChanged.Invoke(value);
                mRunning = value; // <=== LOOK HERE
            }
        }
    }
