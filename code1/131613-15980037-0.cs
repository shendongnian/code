    int attempt = 0;
    while (true)
    {
       try
       {
          using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write)
          {
             ProtoBuf.Serializer.Serialize(stream , value);
          }
          break;
       }
       catch (IOException ex)
       {
          // could be locked by another process
          // make up to X attempts to write the file
          attempt++;
          if (attempt >= X)
          {
             throw;
          }
          Thread.Sleep(100);
       }
    }
