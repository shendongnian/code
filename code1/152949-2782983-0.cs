    void StartReading(Stream responseStream)
    {
        byte [] buffer = new byte[1024];
        Context ctx = new Context();
        ctx.Buffer = buffer;
        ctx.InputStream = responseStream;
        ctx.OutputStream = new MemoryStream(); // change this to be your output stream
    
        responseStream.BeginRead(buffer, 0, buffer.Length; new AsyncCallback(ReadCallback), ctx);
    }
    
    void ReadCallback(IAsyncResult ar)
    {
        Context ctx = (Context)ar.AsyncState;
        int read = 0;
        try {
            read = ctx.InputStream.EndRead(ar);
            if (read > 0)
            {
                ctx.OutputStream.Write(ctx.Buffer, 0, read);
                // kick off another async read
                ctx.InputStream.BeginRead(ctx.Buffer, 0, ctx.Buffer.Length, new AsyncCallback(ReadCallback), ctx);
            } else {
                ctx.InputStream.Close();
                ctx.OutputStream.Close();
            }
         } catch {
         }
    }
    
    }
