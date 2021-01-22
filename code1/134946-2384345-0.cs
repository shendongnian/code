    internal class DatabaseBlobStream : Stream
    {
        private readonly IDataReader reader;
        private readonly int columnIndex;
        private long streamPosition;
        internal DatabaseBlobStream(IDataReader reader, int columnIndex)
        {
            this.reader = reader;
            this.columnIndex = columnIndex;
        }
        public override bool CanRead
        {
            get
            {
                return reader.GetFieldType(columnIndex) == typeof (byte[])
                       && !reader.IsDBNull(columnIndex);
            }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void Flush()
        {
            throw new Exception("This stream does not support writing.");
        }
        public override long Length
        {
            get { throw new Exception("This stream does not support the Length property."); }
        }
        public override long Position
        {
            get
            {
                return streamPosition;
            }
            set
            {
                streamPosition = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (reader.IsDBNull(columnIndex))
                return 0;
            int bytesRead = (int)reader.GetBytes(columnIndex, streamPosition + offset, buffer, 0, count);
            streamPosition += bytesRead;
            return bytesRead;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new Exception("This stream does not support seeking.");
        }
        public override void SetLength(long value)
        {
            throw new Exception("This stream does not support setting the Length.");
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new Exception("This stream does not support writing.");
        }
        public override void Close()
        {
            try
            {
                reader.Close();
            }
            finally
            {
                base.Close();
            }
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                reader.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }
