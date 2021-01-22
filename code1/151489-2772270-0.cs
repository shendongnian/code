    public static string MakeTcpRequest(string message, TcpClient client, bool readToEnd)
    {
        client.ReceiveTimeout = 20000;
        client.SendTimeout = 20000;
        string proxyResponse = string.Empty;
        try
        {
            // Send message
            using (StreamWriter streamWriter = new StreamWriter(client.GetStream()))
            {
                streamWriter.Write(message);
                streamWriter.Flush();
            }
            // Read response
            using (StreamReader streamReader = new StreamReader(client.GetStream()))
            {
                proxyResponse = readToEnd ? streamReader.ReadToEnd() : streamReader.ReadLine();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return proxyResponse;
    }
