    public class MergedStream : Stream, IDisposable
    {
        Stream s1;
        Stream s2;
        public MergedStream(Stream first, Stream second)
        {
            s1 = first;
            s2 = second;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int s1count = (int)Math.Min((long)count, s1.Length - s1.Position);
            int bytesRead = 0;
            if (s1count > 0)
            {
                bytesRead += s1.Read(buffer, offset, s1count);
            }
            if (s1count < count)
            {
                bytesRead += s2.Read(buffer, offset + s1count, count - s1count);
            }
            
            return bytesRead;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead
        {
            get { return s1.CanRead && s2.CanRead; }
        }
        public override bool CanSeek
        {
            get { return s1.CanSeek && s2.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return s1.CanWrite && s2.CanWrite; }
        }
        public override void Flush()
        {
            s1.Flush();
            s2.Flush();
        }
        public override long Length
        {
            get { return s1.Length + s2.Length; }
        }
        public override long Position
        {
            get
            {
                return s1.Position + s2.Position;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        void IDisposable.Dispose()
        {
            s1.Dispose();
            s2.Dispose();
        }
    }
