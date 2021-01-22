    Stream s = myFile.OpenRead();
    int bytesRead = 0;
    byte[] buffer = new byte[32 * 1024] //32k buffer
    while((bytesRead = s.Read(buffer, 0, buffer.Length)) > 0 &&
          Response.IsClientConnected)
    {
       Response.OutputStream.Write(buffer, 0, bytesRead);
       Response.Flush();
    }
