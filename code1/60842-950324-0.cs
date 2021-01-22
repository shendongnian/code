        public NetworkStatus GetNetworkStatus()
        {
            NetworkStatus netStatus = new NetworkStatus();
            netStatus.NetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            try
            {
                if (netStatus.NetworkAvailable)
                {
                    Ping p = new Ping();
                    // Create a buffer of 32 bytes of data to be transmitted.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    PingReply reply = p.Send(DB_SERVER_NAME, 1200, buffer);
                    netStatus.PublisherPingSuccess = reply.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                netStatus.PublisherPingSuccess = false;
                netStatus.Error = ex;
            } 
            return netStatus;
        }
