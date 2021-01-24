        private bool _stop = false;
        public Form1()
        {
            InitializeComponent();
            
            Task.Run(() =>
            {
                while(!_stop)
                {
                    UpdateElapsedTimes();
                    Thread.Sleep(1000);
                }
            }
        }
        private void UpdateElapsedTimes()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateElapsedTimes());
                return;
            }
            label1.Text = sw1.Elapsed.Seconds.ToString();
            label2.Text = sw2.Elapsed.Seconds.ToString();
        }
