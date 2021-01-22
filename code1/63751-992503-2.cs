    String url = ...;
    HttpWebRequest  request  = (HttpWebRequest) WebRequest.Create(url);
    // execute the request
    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    // we will read data via the response stream
    Stream ReceiveStream = response.GetResponseStream();
    string filename = ...;
    byte[] buffer = new byte[1024];
    FileStream outFile = new FileStream(filename, FileMode.Create);
    int bytesRead;
    while((bytesRead = ReceiveStream.Read(buffer, 0, buffer.Length)) != 0)
        outFile.Write(buffer, 0, bytesRead);
    // Or using statement instead
    outFile.Close()
