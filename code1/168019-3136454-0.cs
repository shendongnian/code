    static void Main()
    {
    
        for (int index = 0; index < 999999; index++)
        {
            string computerName = string.Format("ICTLN-D{0:000000}-edw.srv.internal", index);
            string fqdn = computerName;
    
            try
            {
                fqdn = Dns.GetHostEntry(computerName).HostName;
            }
            catch (SocketException exception)
            {
                Console.WriteLine(">>Computer not found: " + computerName + " - " + exception.Message);
            }
    
            using (Ping ping = new Ping())
            {
                PingReply reply = ping.Send(fqdn);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine(">>Computer is alive: " + computerName);
                }
                else
                {
                    Console.WriteLine(">>Computer did not respond to ping: " + computerName);
                }
            }
        }
    }
