    private async Task ReadDataAsync(TcpClient mClient)
    {
        try
        {
            StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
            char[] buff = new char[64];
            int readByteCount = 0;
            while (true)
            {
                readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                if (readByteCount <= 0)
                {
                    Message?.Invoke(this, new MessageEventArgs("Disconnected from server."));
                    Debug.WriteLine("Disconnected from server.");
                    mClient.Close();
                    break;
                }
                Message?.Invoke(this, new MessageEventArgs(string.Format("Received bytes: {0} - Message: {1}",
                    readByteCount, new string(buff))));
                Debug.WriteLine(
                    string.Format("Received bytes: {0} - Message: {1}",
                    readByteCount, new string(buff)));
                Array.Clear(buff, 0, buff.Length);
            }
        }
        catch (Exception excp)
        {
            Console.WriteLine(excp.ToString());
            throw;
        }
    }
