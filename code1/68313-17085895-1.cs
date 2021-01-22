    public class PauseClass
    {
        //(C) Michael Roberg
        //Please feel free to distribute this class but include my credentials.
    
        System.Timers.Timer pauseTimer = null;
    
        public void BreakPause()
        {
            if (pauseTimer != null)
            {
                pauseTimer.Stop();
                pauseTimer.Enabled = false;
            }    
        }
    
        public bool Pause(int miliseconds)
        {
            ThreadPriority CurrentPriority = Thread.CurrentThread.Priority;
    
            if (miliseconds > 0)
            {
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
    
                pauseTimer = new System.Timers.Timer();
                pauseTimer.Elapsed += new ElapsedEventHandler(pauseTimer_Elapsed);
    
                pauseTimer.Interval = miliseconds;
                pauseTimer.Enabled = true;
    
                while (pauseTimer.Enabled)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                    //pausThread.Sleep(1);
                }
    
                pauseTimer.Elapsed -= new ElapsedEventHandler(pauseTimer_Elapsed);
            }
    
            Thread.CurrentThread.Priority = CurrentPriority;
    
            return true;
        }
    
        private void pauseTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            pauseTimer.Enabled = false;
        }
    }
