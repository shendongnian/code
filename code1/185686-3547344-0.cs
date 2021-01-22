    public void AsyncPingCompleted (bla bla bla)
    {
        //[..other code..]
        lock (syncLock) 
        {
            if (omiToIP < omiCurrentIp)
            {
               System.Net.IPAddress sniIPaddress = System.Net.IPAddress.Parse(IPn2IPv4(omiThisIP)); 
               SendPingAsync(sniIPaddress); 
               ++omiCurrentIp;
            }
        }
    }
