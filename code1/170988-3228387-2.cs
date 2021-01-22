    /// <summary>
    /// A stream that, as it reads, makes those bytes available on an ouput
    /// stream. Thread safe.
    /// </summary>
    public class CacheStream : Stream
    {
        private readonly Stream stream;
    
        public CacheStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            this.stream = stream;
            OutputStream = new CacheOutputStream(this);
        }
    
        public event EventHandler<BytesReadEventArgs> BytesRead = delegate { };
        public event EventHandler Closing = delegate { };
    
        public Stream OutputStream { get; private set; }
    
        public override void Flush()
        {
            stream.Flush();
        }
    
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new InvalidOperationException("Cannot seek in CachingStream.");
        }
    
        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }
    
        public override int Read(byte[] buffer, int offset, int count)
        {
            int numberOfBytesRead = stream.Read(buffer, offset, count);
    
            if (numberOfBytesRead > 0)
                PipeToOutputStream(buffer, offset, numberOfBytesRead);
    
            return numberOfBytesRead;
        }
    
        private void PipeToOutputStream(byte[] buffer, int offset, int numberOfBytesRead)
        {
            var tmp = new byte[numberOfBytesRead];
            Array.Copy(buffer, offset, tmp, 0, numberOfBytesRead);
            BytesRead(this, new BytesReadEventArgs(tmp));
        }
    
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException("Cannot write in CachingStream.");
        }
    
        public override bool CanRead
        {
            get { return stream.CanRead; }
        }
    
        public override bool CanSeek
        {
            get { return false; }
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override long Length
        {
            get { return stream.Length; }
        }
    
        public override long Position
        {
            get { return stream.Position; }
            set { throw new InvalidOperationException("Cannot set position in CachingStream."); }
        }
    
        public override void Close()
        {
            Closing(this, EventArgs.Empty);
            base.Close();
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            OutputStream.Dispose();
        }
    }
   
