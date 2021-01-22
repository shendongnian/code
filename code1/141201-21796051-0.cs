        private void myPingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                return;
            if (e.Reply.Status == IPStatus.Success)
            {
                //ok connected to internet, do something...
            }
        }
        private void checkInternet()
        {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(myPingCompletedCallback);
            try
            {
                myPing.SendAsync("google.com", 3000 /*3 secs timeout*/, new byte[32], new PingOptions(64, true));
            }
            catch
            {
            }
        }
 
