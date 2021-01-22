    stream = new System.IO.FileStream(path,
        System.IO.FileMode.Open,
        System.IO.FileAccess.Read,
        System.IO.FileShare.ReadWrite,
        SG.CompoundDocumentIO.Storage.OpenBufferLength);
    try
    {
        stream.Lock(0, stream.Length);
    }
    catch
    {
        // .NET 1.1 requires cast to IDisposable
        ((IDisposable)stream).Dispose();
        throw;
    }
