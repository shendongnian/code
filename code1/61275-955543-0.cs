    private bool ValidSMTP(string hostName)
    {
        bool valid = false;
        try
        {
            TcpClient smtpTest = new TcpClient();
            smtpTest.Connect(hostName, 25);
            if (smtpTest.Connected)
            {
                NetworkStream ns = smtpTest.GetStream();
                StreamReader sr = new StreamReader(ns);
                if (sr.ReadLine().Contains("220"))
                {
                    valid = true;
                }
                smtpTest.Close();
            }
        }
        catch
        {
        }
        return valid;
    }
