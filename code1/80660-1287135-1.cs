    using (TcpClient client = new TcpClient())
    {
        client.Connect("VM-SCHEDULER", 400);
        using (NetworkStream netStream = client.GetStream())
        {
            Byte[] data = Encoding.ASCII.GetBytes("R");
            netStream.Write(data, 0, data.Length);
            netStream.Flush();
        }
        client.Close();
    }
