    /// <summary>
    /// Gets the whois information.
    /// </summary>
    /// <param name="whoisServer">The whois server.</param>
    /// <param name="url">The URL.</param>
    /// <returns></returns>
    private string GetWhoisInformation(string whoisServer, string url)
    {
        StringBuilder stringBuilderResult = new StringBuilder();
        TcpClient tcpClinetWhois = new TcpClient(whoisServer, 43);
        NetworkStream networkStreamWhois = tcpClinetWhois.GetStream();
        BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois);
        StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois);
    
        streamWriter.WriteLine(url);
        streamWriter.Flush();
    
        StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois);
    
        while (!streamReaderReceive.EndOfStream)
            stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());
    
        return stringBuilderResult.ToString();
    }
