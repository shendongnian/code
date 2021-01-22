        System.Timers.Timer timer = new System.Timers.Timer(1000);
       
        public void StartTimer()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerHandler);
            timer.Start();
        }
        private void TimerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime start;
            TimeSpan elapsed = TimeSpan.MaxValue;
            timer.Stop();
            while (elapsed.TotalSeconds > 1.0)
            {
                start = DateTime.Now;
                // check your website here
                elapsed = DateTime.Now - start;
            }
            timer.Interval = 1000 - elapsed.TotalMilliseconds;
            timer.Start();
        }
