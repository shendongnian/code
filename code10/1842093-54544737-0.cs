    class TestService
    {
        private Timer scheduledReloadTimer;
        private object timerLock = new object();
    
        public void AttemptReload()
        {
            lock (timerLock)
            {
                if (scheduledReloadTimer == null)
                {
                    Console.WriteLine("Scheduling reload...");
    
                    scheduledReloadTimer = new Timer(Reload, null, 10000, Timeout.Infinite);
                }
                else
                {
                    Console.WriteLine("Reload already scheduled for this period...");
                } 
            }
        }
    
        private void Reload(object stateInfo)
        {
            lock (timerLock)
            {
                scheduledReloadTimer.Dispose();
                scheduledReloadTimer = null; 
            }
    
            Console.WriteLine("Doing reload..");
        }
    }
