        System.Timers.Timer timer = new System.Timers.Timer(1000);
       
        public void StartTimer()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerHandler);
            timer.Start();
        }
        private void TimerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            // check your website
            timer.Start();
        }
