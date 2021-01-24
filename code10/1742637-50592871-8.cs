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
            label1.Text = Math.Floor(sw1.Elapsed.TotalSeconds).ToString();
            label2.Text = Math.Floor(sw2.Elapsed.TotalSeconds).ToString();
        }
