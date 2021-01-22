        private bool isValidSMTP(string hostName)
        {
            bool hostAvailable= false;
            try
            {
                TcpClient smtpTestClient = new TcpClient();
                smtpTestClient.Connect(hostName, 25);
                if (smtpTestClient.Connected)//connection is established
                {
                    NetworkStream netStream = smtpTestClient.GetStream();
                    StreamReader sReader = new StreamReader(netStream);
                    if (sReader.ReadLine().Contains("220"))//host is available for communication
                    {
                        hostAvailable= true;
                    }
                    smtpTestClient.Close();
                }
            }
            catch
            {
              //some action like writing to error log
            }
            return hostAvailable;
        }
