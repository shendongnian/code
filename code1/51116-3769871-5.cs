    using (TcpClient tcp = new TcpClient())  
    {  
        IAsyncResult ar = tcp.BeginConnect("127.0.0.1", 80, null, null);  
        System.Threading.WaitHandle wh = ar.AsyncWaitHandle;  
        try 
        {  
           if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))  
           {  
               tcp.Close();  
               throw new TimeoutException();  
           }  
 
            tcp.EndConnect(ar);  
        }  
        finally 
        {  
            wh.Close();  
        }  
    }
