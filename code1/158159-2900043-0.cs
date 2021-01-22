    public void ParseNetworkPacket(IAsyncResult iResult)
        {
            NetworkConnection networkConnection = (NetworkConnection)iResult.AsyncState;
    
            string teste = NetworkPacketType.ToString();
    
            string methodName = this.NetworkPacketType.ToString();
    
            MethodInfo methodInfo = GetType().GetMethod(methodName, 
                BindingFlags.Instance | BindingFlags.NonPublic);
    
            methodInfo.Invoke(this, /* your arguments here */);
    
            networkConnection.BeginReadPacket();
        }
    private void ShotPacket() 
    {
        ....
    }
