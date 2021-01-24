    public class YourClass : IDisposable
    {
        private readonly DispatcherTimer m_timer;
       
        public YourClass()
        {
              m_timer = new DispatcherTimer();
              m_timer.Interval = new TimeSpan(0, 0, 1);
              m_timer.Tick += setTime;            
        }
    
        public void Dispose()
        {
              m_timer.Tick -= setTime;    
              m_timer.Stop(); 
        }
    
        private void startTime(bool what)
        {
            if(what == false)
            {
                MessageBox.Show("Start");
    
                m_timer.Start();
            }
    
            if(what == true)
            {
                MessageBox.Show("Stop");
    
                m_timer.Stop();
            }
        }
    }
