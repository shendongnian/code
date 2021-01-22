    int Readed = 0;
    IAsyncResult ReadResult;
    IAsyncResult WriteResult;
    ReadResult = sourceStream.BeginRead(ActiveBuffer, 0, ActiveBuffer.Length, null, null);
    do
    {
        Readed = sourceStream.EndRead(ReadResult);
        WriteResult = destStream.BeginWrite(ActiveBuffer, 0, Readed, null, null);
        WriteBuffer = ActiveBuffer;
        if (Readed > 0)
        {
          ReadResult = sourceStream.BeginRead(BackBuffer, 0, BackBuffer.Length, null, null);
          BackBuffer = Interlocked.Exchange(ref ActiveBuffer, BackBuffer);
        }
        destStream.EndWrite(WriteResult);
      }
      while (Readed > 0);
