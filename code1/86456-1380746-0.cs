        public class StreamWatcher : Stream
        {
            private Stream _base;
            private MemoryStream _memoryStream = new MemoryStream();
    
            public StreamWatcher(Stream stream)
            {
                _base = stream;
            }
    
            public override void Flush()
            {
                _base.Flush();
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _base.Read(buffer, offset, count);
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                _memoryStream.Write(buffer, offset, count);
                _base.Write(buffer, offset, count);
            }
    
            public override string ToString()
            {
                return Encoding.UTF8.GetString(_memoryStream.ToArray());
            }
    
            #region Rest of the overrides
            public override bool CanRead
            {
                get { throw new NotImplementedException(); }
            }
    
            public override bool CanSeek
            {
                get { throw new NotImplementedException(); }
            }
    
            public override bool CanWrite
            {
                get { throw new NotImplementedException(); }
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }
    
            public override void SetLength(long value)
            {
                throw new NotImplementedException();
            }
    
            public override long Length
            {
                get { throw new NotImplementedException(); }
            }
    
            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
            #endregion
        }
