        /// <summary>
        /// Copies a stream.
        /// </summary>
        /// <param name="source">The stream containing the source data.</param>
        /// <param name="target">The stream that will receive the source data.</param>
        /// <remarks>
        /// This function copies until no more can be read from the stream and does not
        ///  close the stream when done.<br/>
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
                // Read data into the readbuffer.  (If this is not the first iteration,
                //  the writebuffer is simultaneously being used to write the previous read.)
                int read = source.Read(readbuffer, 0, readbuffer.Length);
                // Wait until the previous write has completed, if there was a previous write.
                if (asyncResult != null)
                {
                    // This should work down to ~0.01kb/sec
                    asyncResult.AsyncWaitHandle.WaitOne(60000);
                    target.EndRead(asyncResult);
                    if (!asyncResult.IsCompleted)
                        throw new IOException("Stream write failed.");
                }
                if (read <= 0)
                    return;
                // Swap the read and write buffers so we write what we read, and we can
                //  read-in to where from we are done writing.  (You will be quizzed later.)
                byte[] tbuf = writebuffer;
                writebuffer = readbuffer;
                readbuffer = tbuf;
                // Asynchronously write the data, then set writeComplete when done.
                asyncResult = target.BeginWrite(writebuffer, 0, read, null, null);
            }
        }
