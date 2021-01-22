    /// <summary>
    /// Copies a stream.
    /// </summary>
    /// <param name="source">The stream containing the source data.</param>
    /// <param name="target">The stream that will receive the source data.</param>
    /// <remarks>
    /// This function copies until no more can be read from the stream
    ///  and does not close the stream when done.<br/>
    /// Read and write are performed simultaneously to improve throughput.<br/>
    /// If no data can be read for 60 seconds, the copy will time-out.
    /// </remarks>
    public static void CopyStream(Stream source, Stream target)
    {
        // This stream copy supports a source-read happening at the same time
        // as target-write.  A simpler implementation would be to use just
        // Write() instead of BeginWrite(), at the cost of speed.
        byte[] readbuffer = new byte[4096];
        byte[] writebuffer = new byte[4096];
        IAsyncResult asyncResult = null;
        for (; ; )
        {
            // Read data into the readbuffer.  The previous call to BeginWrite, if any,
            //  is executing in the background..
            int read = source.Read(readbuffer, 0, readbuffer.Length);
            // Ok, we have read some data and we're ready to write it, so wait here
            //  to make sure that the previous write is done before we write again.
            if (asyncResult != null)
            {
                // This should work down to ~0.01kb/sec
                asyncResult.AsyncWaitHandle.WaitOne(60000);
                target.EndWrite(asyncResult); // Last step to the 'write'.
                if (!asyncResult.IsCompleted) // Make sure the write really completed.
                    throw new IOException("Stream write failed.");
            }
            if (read <= 0)
                return; // source stream says we're done - nothing else to read.
            // Swap the read and write buffers so we can write what we read, and we can
            //  use the then use the other buffer for our next read.
            byte[] tbuf = writebuffer;
            writebuffer = readbuffer;
            readbuffer = tbuf;
            // Asynchronously write the data, asyncResult.AsyncWaitHandle will
            // be set when done.
            asyncResult = target.BeginWrite(writebuffer, 0, read, null, null);
        }
    }
