    public override int Read(byte[] buffer, int offset, int count)
    {
        int totalBytesRead = 0;
        int chunkBytesRead = 0;
        do
        {
            chunkBytesRead = _stream.Read(buffer, offset + totalBytesRead, Math.Min(__frameSize, count - totalBytesRead));
            totalBytesRead += chunkBytesRead;
        } while (totalBytesRead < count && chunkBytesRead > 0);
        return totalBytesRead;
    }
        public override void Write(byte[] buffer, int offset, int count)
        {
            int bytesSent = 0;
            do
            {
                int chunkSize = Math.Min(__frameSize, count - bytesSent);
                _stream.Write(buffer, offset + bytesSent, chunkSize);
                bytesSent += chunkSize;
            } while (bytesSent < count);
        }
    //_stream is the wrapped stream
    //__frameSize is a constant, we use 4096 since its easy to allocate.
