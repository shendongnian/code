    public static void Read_Callback(IAsyncResult ar)
    {
        StateObject so = (StateObject) ar.AsyncState;
        Socket s = so.workSocket;
        
        int read = s.EndReceive(ar);    
        if (read > 0) 
        {
            so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
            if (s.Available == 0)
            {
                // All data received, process it as you wish
            }
        }
        // Listen for more data
        s.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, 
                    new AyncCallback(Async_Send_Receive.Read_Callback), so);
    }
