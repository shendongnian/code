    private static void InitTimer(int Index)
    {
        keepAlive[Index] = new Timer();
        keepAlive[Index].Interval = 3000;
        keepAlive[Index].Elapsed += delegate { KeepAliveElapsed(Index); };
        keepAlive[Index].Start();
    }
    
    public static void KeepAliveElapsed(int Index)
    {    
        PacketWriter writer = new PacketWriter();
        writer.AppendString("KEEPALIVE|.\\");
        ServerSocket.Send(writer.getWorkspace(), Index);
        ServerSocket.DisconnectSocket(Index);
    }
