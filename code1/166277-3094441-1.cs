    private static void InitTimer(int Index)
    {
        keepAlive[Index] = new Timer();
        keepAlive[Index].Interval = 3000;
        keepAlive[Index].Elapsed += (sender, args) => KeepAliveElapsed(sender, Index);
        keepAlive[Index].Start();
    }
    
    public static void KeepAliveElapsed(object sender, int Index)
    {    
        PacketWriter writer = new PacketWriter();
        writer.AppendString("KEEPALIVE|.\\" + sender);
        ServerSocket.Send(writer.getWorkspace(), Index);
        ServerSocket.DisconnectSocket(Index);
    }
