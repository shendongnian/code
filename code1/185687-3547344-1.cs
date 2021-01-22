    public void AsyncPingCompleted (bla bla bla)
    {
        //[..other code..]
        lock (syncLock) 
        {
            if (omiToIP < omiCurrentIp)
            {
               ++omiCurrentIp;
               System.Net.IPAddress sniIPaddress = System.Net.IPAddress.Parse(IPn2IPv4(omiCurrentIp)); 
               SendPingAsync(sniIPaddress); 
            }
        }
    }
