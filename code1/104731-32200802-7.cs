    public List<string> GetFileNames()
    {
        if (!bConnected)
        {
            Open();
        }
        List<string> retObj = new List<string>();
        Socket dataSock =  BuildDataConn(mySocket);
        SendCommand("NLST");
        string dataSockMsg = "";
        buffer = new byte[BLOCK_SIZE];
        while (true)
        {
            int iBytes = dataSock.Receive(buffer, buffer.Length, 0);
            dataSockMsg += System.Text.Encoding.ASCII.GetString(buffer, 0, iBytes);
            if (iBytes < buffer.Length)
            {
                break;
            }
        }
        string[] message = dataSockMsg.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);     
        dataSock.Close();
        foreach (string obj in message)
        {
            retObj.Add(obj);
        }
            
        return retObj;
    }
