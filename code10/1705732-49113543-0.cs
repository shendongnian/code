    static void Main(string[] args)
    {
        List<string> HostAdrr = new List<string>() { "192.168.2.1", "192.168.2.201", 
                                                     "192.168.1.99", "200.1.1.1", 
                                                     "www.microsoft.com", "www.hfkhkhfhkf.com" };
        IPStatus _result;;
        foreach (string _Host in HostAdrr)
        {
            Stopwatch timer = Stopwatch.StartNew();
            _result = PingHostAddress(_Host, 1000);
            timer.Stop();
            Console.WriteLine("Host: {0}  Elapsed time: {1}ms  Result: {2}", _Host, timer.ElapsedMilliseconds, _result);
            Console.WriteLine();
        }
        Console.ReadLine();
    }
    public static IPStatus PingHostAddress(string HostAddress, int timeout)
    {
        if (string.IsNullOrEmpty(HostAddress.Trim()))
            return IPStatus.BadDestination;
        byte[] buffer = new byte[32];
        PingReply iReplay = null;
        using (Ping iPing = new Ping())
        {
            try
            {
                //IPAddress _HostIPAddress = Dns.GetHostAddresses(HostAddress).First();
                iReplay = iPing.Send(HostAddress,
                                        timeout,
                                        buffer,
                                        new PingOptions(64, true));
            }
            catch (FormatException)
            {
                return IPStatus.BadDestination;
            }
            catch (NotSupportedException nsex)
            {
                throw nsex;
            }
            catch (PingException pex)
            {
                //Log/Manage pex
            }
            //catch (SocketException soex)
            //{
            //
            //}
            catch (Exception ex)
            {
                //Log/Manage ex
            }
            return (iReplay != null) ? iReplay.Status : IPStatus.BadDestination;
        }
    }
