    public byte[] SendPassiveFTPcmd(string cmd)
    {
        using (Stream passiveConnection = CreatePassiveConnections())
        {
            byte[] commandData = Encoding.ASCII.GetBytes(cmd);
            NetStrm.Write(commandData, 0, commandData.Length);
            tbStatus.Text += "\r\nSent:" + cmd;
 
            byte[] data = ReadFully(passiveConnection);
            StreamReader commandStream = new StreamReader(NetStrm);
            tbStatus.Text += "\r\nRcvd:" + commandStream.ReadLine(); // 125
            tbStatus.Text += "\r\nRcvd:" + commandStream.ReadLine(); // 226
            return data;
        }
    }
