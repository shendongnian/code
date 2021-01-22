        System.Timers.Timer timer = new System.Timers.Timer(1000);
       
        public void StartTimer()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerHandler);
            timer.Start();
        }
        private void TimerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            // stop the timer so you don't have to worry about how long things take
            timer.Stop();
            // check your website here
            // then restart the timer
            timer.Start();
        }
