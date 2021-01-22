    string strIP = "10.0.0.0";
    int intPort = 12345;
      public static bool PingHost(string strIP , int intPort )
        {
            bool blProxy= false;
            try
            {
                TcpClient client = new TcpClient(strIP ,intPort );
               
                blProxy = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pinging host:'" + strIP + ":" + intPort .ToString() + "'");
                return false;
            }
            return blProxy;
        }
        public void Proxy()
        {
            bool tt = PingHost(strIP ,intPort );
            if(tt == true)
            {
                MessageBox.Show("tt True");
            }
            else
            {
                MessageBox.Show("tt False");
            }
