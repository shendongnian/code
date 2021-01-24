    void MyEventOnElapsed(object sender, ElapsedEventArgs e)
    {
        lock(aLockObject) 
        {
            if (myTimerObject.Enabled)
            {    try
                 { 
                     myTimerObject.Stop();
                     // Perform actions that can exceed the interval time set in the timer
                 }
                 finally 
                 {
                     myTimerObject.Start();
                 }
            }
        }
    }
