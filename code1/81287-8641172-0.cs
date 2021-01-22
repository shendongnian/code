      private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.TimerCallback callback = new System.Threading.TimerCallback(ProcessTimerEvent);
            var dt =    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day   , 10, 0, 0);
            if (DateTime.Now < dt)
            {
                var timer = new System.Threading.Timer(callback, null, dt - DateTime.Now, TimeSpan.FromHours(24));
            }
             
        }
        private void ProcessTimerEvent(object obj)
        {
            MessageBox.Show("Hi Its Time");
        }
