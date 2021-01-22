    private AutoResetEvent polledEvent = new AutoResetEvent(true);
    public void Read(Program program)
    {
        polledEvent.WaitOne();
        ThreadPool.QueueUserWorkItem(s => 
        {
            try
            {
                program.Poll();
            }
            catch (PollingException ex)
            {
                // Handle the exception
            }
            polledEvent.Set();
        });
    }
