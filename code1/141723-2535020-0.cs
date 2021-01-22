    private AutoResetEvent playEvent = new AutoResetEvent(true);
    public void Play(Sound sound)
    {
        ThreadPool.QueueUserWorkItem(s =>
        {
            if (playEvent.WaitOne(0))
            {
                // Play the sound here
                playEvent.Set();
            }
        });
    }
