    public static void CopyStreamToStream(
        Stream source, Stream destination,
        Action<Stream, Stream, Exception> completed)
        {
            byte[] buffer = new byte[0x1000];
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(null);
    
            Action<Exception> done = e =>
            {
                if(completed != null) asyncOp.Post(delegate
                    {
                        completed(source, destination, e);
                    }, null);
            };
    
            AsyncCallback rc = null;
            rc = readResult =>
            {
                try
                {
                    int read = source.EndRead(readResult);
                    if(read > 0)
                    {
                        destination.BeginWrite(buffer, 0, read, writeResult =>
                        {
                            try
                            {
                                destination.EndWrite(writeResult);
                                source.BeginRead(
                                    buffer, 0, buffer.Length, rc, null);
                            }
                            catch(Exception exc) { done(exc); }
                        }, null);
                    }
                    else done(null);
                }
                catch(Exception exc) { done(exc); }
            };
    
            source.BeginRead(buffer, 0, buffer.Length, rc, null);
