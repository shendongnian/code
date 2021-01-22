        private void OnClientConnect(IAsyncResult asyn)
        {
            m_Client = m_Listener.EndAccept(asyn);
            WaitForData();
        }
        private void WaitForData()
        {
            buffer = new byte[1024];
            m_Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
        }
        private void OnDataReceived(IAsyncResult asyn)
        {
            int iRx = 0;
            iRx = m_Client.EndReceive(asyn);
            if (iRx > 0)
            {
                PacketReceiver.BytesReceived(buffer);
            }
            if (m_Client.Connected == true)
                WaitForData();
        }
