    public void WakeUp()
    {
       t1.Interrupt();
    }
    public void StopRunningImmediately()
    {
       keepRunning = false;
       WakeUp(); //immediately
    }
