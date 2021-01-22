    public ConnectionOpen(data)  
    {  
        Connection conn=new ...  
        lock(Connections)  
        {  
             Connections.Add(conn);  
        }  
      
        new Thread(()=>  
        {  
            Receive(conn);//infinite loop goes here  
        }).Start();  
    }  
      
    public ConnectionClose(conn)  
    {  
        bool removed=false;  
        lock(Connections)  
        {  
            removed=Connections.Remove(conn);  
        }  
        if(removed) conn.StopReceiving();  
    }  
