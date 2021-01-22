    public sealed class ChunkedMemoryStream : Stream
    {
        private const byte ONE = 1;
        private const byte ZERO = 0;
        private const int BUFFER_LENGTH = 65536;
        private readonly Collection<byte[]> _chunks;
        private long _length;
        private long _position;
        public ChunkedMemoryStream()
        {
            _chunks = new Collection<byte[]> {new byte[BUFFER_LENGTH]};
            _position = ZERO;
            _length = ZERO;
        }
        #region Overrides of Stream
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
        public override long Length
        {
            get { return _length; }
        }
        public override long Position
        {
            get { return _position; }
            set
            {
                if (!CanSeek)
                    throw new NotSupportedException();
                _position = value;
                if (_position > _length - ONE)
                    _position = _length - ONE;
            }
        }
        private int PositionInChunk
        {
            get
            {
                int positionInChunk = Convert.ToInt32(_position%BUFFER_LENGTH);
                return positionInChunk;
            }
        }
        private byte[] CurrentChunk
        {
            get
            {
                int chunkIndex = Convert.ToInt32(_position/BUFFER_LENGTH);
                byte[] chunk = _chunks[chunkIndex];
                return chunk;
            }
        }
        private int RemainingBytesInCurrentChunk
        {
            get
            {
                int remainingBytesInCurrentChunk = CurrentChunk.Length - PositionInChunk;
                return remainingBytesInCurrentChunk;
            }
        }
        public override void Flush()
        {
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
                case SeekOrigin.End:
                    Position = Length + offset;
                    break;
            }
            return Position;
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset + count > buffer.Length)
                throw new ArgumentException();
            if (buffer == null)
                throw new ArgumentNullException();
            if (offset < ZERO || count < ZERO)
                throw new ArgumentOutOfRangeException();
            if (!CanRead)
                throw new NotSupportedException();
            int bytesToRead = count;
            if (_length - _position < bytesToRead)
                bytesToRead = Convert.ToInt32(_length - _position);
            int bytesreaded = 0;
            while (bytesToRead > ZERO)
            {
                // get remaining bytes in current chunk
                // read bytes in current chunk
                // advance to next position
                int remainingBytesInCurrentChunk = RemainingBytesInCurrentChunk;
                if (remainingBytesInCurrentChunk > bytesToRead)
                    remainingBytesInCurrentChunk = bytesToRead;
                Array.Copy(CurrentChunk, PositionInChunk, buffer, offset, remainingBytesInCurrentChunk);
                //move position in source
                _position += remainingBytesInCurrentChunk;
                //move position in target
                offset += remainingBytesInCurrentChunk;
                //bytesToRead is smaller
                bytesToRead -= remainingBytesInCurrentChunk;
                //count readed bytes;
                bytesreaded += remainingBytesInCurrentChunk;
            }
            return bytesreaded;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (!CanWrite)
                throw new NotSupportedException();
            int bytesToWrite = count;
            while (bytesToWrite > ZERO)
            {
                //get remaining space in current chunk
                int remainingBytesInCurrentChunk = RemainingBytesInCurrentChunk;
                //if count of bytes to be written is fewer than remaining
                if (remainingBytesInCurrentChunk > bytesToWrite)
                    remainingBytesInCurrentChunk = bytesToWrite;
                //if remaining bytes is still greater than zero
                if (remainingBytesInCurrentChunk > ZERO)
                {
                    //write remaining bytes to current Chunk
                    Array.Copy(buffer, offset, CurrentChunk, PositionInChunk, remainingBytesInCurrentChunk);
                    //change offset of source array
                    offset += remainingBytesInCurrentChunk;
                    //change bytes to write
                    bytesToWrite -= remainingBytesInCurrentChunk;
                    //change length and position
                    _length += remainingBytesInCurrentChunk;
                    _position += remainingBytesInCurrentChunk;
                }
                
                long capacity = _chunks.Count*BUFFER_LENGTH;
                if (capacity == _position)
                    _chunks.Add(new byte[BUFFER_LENGTH]);
            }
        }
        #endregion
    }
