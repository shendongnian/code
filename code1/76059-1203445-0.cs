    class ChunkedMemoryStream : Stream
    {
        private readonly List<byte[]> _chunks = new List<byte[]>();
        private int _positionChunk;
        private int _positionOffset;
        private long _position;
        public override bool CanRead
        {
            get { return true; }
        }
        public override bool CanSeek
        {
            get { return true; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void Flush() { }
        public override long Length
        {
            get { return _chunks.Sum(c => c.Length); }
        }
        public override long Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                _positionChunk = 0;
                while (_positionOffset != 0)
                {
                    if (_positionChunk >= _chunks.Count)
                        throw new OverflowException();
                    if (_positionOffset < _chunks[_positionChunk].Length)
                        return;
                    _positionOffset -= _chunks[_positionChunk].Length;
                    _positionChunk++;
                }
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = 0;
            while ((count != 0) && (_positionChunk != _chunks.Count))
            {
                int fromChunk = Math.Min(count, _chunks[_positionChunk].Length - _positionOffset);
                if (fromChunk != 0)
                {
                    Array.Copy(_chunks[_positionChunk], _positionOffset, buffer, offset, fromChunk);
                    offset += fromChunk;
                    count -= fromChunk;
                    result += fromChunk;
                    _position += fromChunk;
                }
                _positionOffset = 0;
                _positionChunk++;
            }
            return result;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPos = 0;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPos = offset;
                    break;
                case SeekOrigin.Current:
                    newPos = Position + offset;
                    break;
                case SeekOrigin.End:
                    newPos = Length - offset;
                    break;
            }
            Position = Math.Max(0, Math.Min(newPos, Length));
            return newPos;
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            while ((count != 0) && (_positionChunk != _chunks.Count))
            {
                int toChunk = Math.Min(count, _chunks[_positionChunk].Length - _positionOffset);
                if (toChunk != 0)
                {
                    Array.Copy(buffer, offset, _chunks[_positionChunk], _positionOffset, toChunk);
                    offset += toChunk;
                    count -= toChunk;
                    _position += toChunk;
                }
                _positionOffset = 0;
                _positionChunk++;
            }
            if (count != 0)
            {
                byte[] chunk = new byte[count];
                Array.Copy(buffer, offset, chunk, 0, count);
                _chunks.Add(chunk);
                _positionChunk = _chunks.Count;
                _position += count;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChunkedMemoryStream cms = new ChunkedMemoryStream();
            Debug.Assert(cms.Length == 0);
            Debug.Assert(cms.Position == 0);
            cms.Position = 0;
            byte[] helloworld = Encoding.UTF8.GetBytes("hello world");
            cms.Write(helloworld, 0, 3);
            cms.Write(helloworld, 3, 3);
            cms.Write(helloworld, 6, 5);
            Debug.Assert(cms.Length == 11);
            Debug.Assert(cms.Position == 11);
            cms.Position = 0;
            byte[] b = new byte[20];
            cms.Read(b, 3, (int)cms.Length);
            Debug.Assert(b.Skip(3).Take(11).SequenceEqual(helloworld));
            cms.Position = 0;
            cms.Write(Encoding.UTF8.GetBytes("seeya"), 0, 5);
            Debug.Assert(cms.Length == 11);
            Debug.Assert(cms.Position == 5);
            cms.Position = 0;
            cms.Read(b, 0, (byte) cms.Length);
            Debug.Assert(b.Take(11).SequenceEqual(Encoding.UTF8.GetBytes("seeya world")));
            Debug.Assert(cms.Length == 11);
            Debug.Assert(cms.Position == 11);
            cms.Write(Encoding.UTF8.GetBytes(" again"), 0, 6);
            Debug.Assert(cms.Length == 17);
            Debug.Assert(cms.Position == 17);
            cms.Position = 0;
            cms.Read(b, 0, (byte)cms.Length);
            Debug.Assert(b.Take(17).SequenceEqual(Encoding.UTF8.GetBytes("seeya world again")));
        }
    }
