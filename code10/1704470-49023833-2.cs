    private void Form1_Load(object sender, EventArgs e)
        {
            var result = TryToConnect();
        }
        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                return;
            if (e.Reply.Status == IPStatus.Success)
            {
            }
        }
        private bool TryToConnect()
        {
            Ping myPing = new Ping();
            int timeOutMS = 5000; //5 seconds
            myPing.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
            try
            {
                myPing.SendAsync("www.google.com", timeOutMS);
                return true;
            }
            catch
            {
                return false;
            }
        }
