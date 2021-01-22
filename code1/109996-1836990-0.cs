    delegate string ReadLineDelegate ();
    ...
    using (NetworkStream networkStream = tcpClient.GetStream()) {
        StreamReader reader = new StreamReader(networkStream);
        ReadLineDelegate rl = new ReadLineDelegate (reader.ReadLine);
        while (true) {
            IAsyncResult ares = rl.BeginInvoke (null, null);
            if (ares.AsyncWaitHandle.WaitOne (100) == false)
                break; // stop after waiting 100ms
            string str = rl.EndInvoke (ares);
            if (str != null) {
                Console.WriteLine ("Received: {0}", str);
                send (str);
            } 
        }
    }
    
