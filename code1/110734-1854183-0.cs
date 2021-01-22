    public class LengthLoggingStream : Stream
    {
        private Stream stream;
        public long TotalBytesRead { get; private set; }
        public long TotalBytesWritten { get; private set; }
        public LengthLoggingStream(Stream stream)
        {
            this.stream = stream;
        }
        public override bool CanRead
        {
            get { return stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return stream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }
        public override void Flush()
        {
            stream.Flush();
        }
        public override long Length
        {
            get { return stream.Length; }
        }
        public override long Position
        {
            get
            {
                return stream.Position;
            }
            set
            {
                stream.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = stream.Read(buffer, offset, count);
            if (bytesRead > 0)
                TotalBytesRead += bytesRead;
            return bytesRead;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            TotalBytesWritten += count;
            stream.Write(buffer, offset, count);
        }
    }
