    StringBuilder stringBuilderResult = new StringBuilder();
    using(TcpClient tcpClinetWhois = new TcpClient(whoIsServer, 43))
    {
       using(NetworkStream networkStreamWhois = tcpClinetWhois.GetStream())
       {
          using(BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois))
          {
             using(StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois))
             {
                streamWriter.WriteLine(url);
                streamWriter.Flush();
                using (StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois))
                {
                   while (!streamReaderReceive.EndOfStream) stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());
                }
             }
          }
       }
    }
