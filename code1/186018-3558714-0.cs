     private void Delay()
            {
                DelayTimer dt = new DelayTimer(1);
                Thread thread = new Thread(new ThreadStart(dt.AddDelay));
                thread.Start();
                while (thread.IsAlive)
                {
                    Application.DoEvents();
                }
                
            }
    
    public class DelayTimer
        {
            private int _seconds;
            public DelayTimer(int time)
            {
                _seconds = time;
            }
            public void AddDelay()
            {
               Thread.Sleep(_seconds*1000);
            }
        }
