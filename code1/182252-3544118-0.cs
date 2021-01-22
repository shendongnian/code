    class FauxFileStream : FileStream
    {
        private Stream _underlying;
        public FauxFileStream(Stream underlying)
        {
            _underlying = underlying;
        }
        public override bool CanRead { get { return _underlying.CanRead; } }
        public override bool CanSeek { get { return _underlying.CanSeek; } }
        public override bool CanTimeout { get { return _underlying.CanTimeout; } }
        public override bool CanWrite { get { return _underlying.CanWrite; } }
        public override long Length { get { return _underlying.Length; } }
        public override long Position { get { return _underlying.Position; } set { _underlying.Position = value; } }
        public override int ReadTimeout { get { return _underlying.ReadTimeout; } set { _underlying.ReadTimeout = value; } }
        public override int WriteTimeout { get { return _underlying.WriteTimeout; } set { _underlying.WriteTimeout = value; } }
        public override void Close() { _underlying.Close(); }
        public override void Flush() { _underlying.Flush(); }
        public override int Read(byte[] buffer, int offset, int count) { return _underlying.Read(buffer, offset, count); }
        public override int ReadByte() { return _underlying.ReadByte(); }
        public override long Seek(long offset, SeekOrigin origin) { return _underlying.Seek(offset, origin); }
        public override void SetLength(long value) { _underlying.SetLength(value); }
        public override void Write(byte[] buffer, int offset, int count) { _underlying.Write(buffer, offset, count); }
        public override void WriteByte(byte value) { _underlying.WriteByte(value); }
    }
