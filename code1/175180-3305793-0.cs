    using System;
    using System.Timers;
    
    namespace TimerApp
    {
        class Program : IDisposable
        {
            private Timer timer;
    
            public Program()
            {
                this.timer = new Timer();
                this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                this.timer.AutoReset = true;
                this.timer.Interval = TimeSpan.FromMinutes(10).TotalMilliseconds;
            }
    
            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                // TODO...your periodic processing, executed in a worker thread.
            }
    
            static void Main(string[] args)
            {
                // TODO...your app logic.
            }
    
            public void Start()
            {
                this.timer.Start();
            }
    
            public void Stop()
            {
                this.timer.Stop();
            }
    
            public void Dispose()
            {
                this.timer.Dispose();
            }
        }
    }
