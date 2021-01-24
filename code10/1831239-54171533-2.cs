    void BroadcastClients(string BroadcastingMsg)
    {
        if (mlClientSocks.Count() <= 0)
            return;
        else
        {
            ClientNode cn = null;
            mlClientSocks.ForEach(delegate (ClientNode clntN)
            {
                cn = clntN;
                try
                {
                    // broadcasting online clients list
                    cn.Tx = Encoding.ASCII.GetBytes(BroadcastingMsg);
                    cn.tclient.GetStream().BeginWrite(cn.Tx, 0, cn.Tx.Length, onCompleteWriteToClientStream, cn.tclient);
                }
                catch (Exception e)
                {
                    // handle exception 
                }
            });
        }
    }
