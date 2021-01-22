    var tcp = new TcpClient();
    var ar = tcp.BeginConnect(Ip, Port, null, null);
    Task.Factory.StartNew(() =>
    {
        var wh = ar.AsyncWaitHandle;
        try
        {
            if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                // The logic to control when the connection timed out
                tcp.Close();
                throw new TimeoutException();
            }
            else
            {
                // The logic to control when the connection succeed.
                tcp.EndConnect(ar);
             }
         }
         finally
         {
             wh.Close();
         }
    });
