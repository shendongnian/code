        public sealed class ChunkedMemoryStream : Stream
    {
        #region Constants
        private const int BUFFER_LENGTH = 65536;
        private const byte ONE = 1;
        private const byte ZERO = 0;
        #endregion
        #region Readonly & Static Fields
        private readonly Collection<byte[]> _chunks;
        #endregion
        #region Fields
        private long _length;
        private long _position;
        private const byte TWO = 2;
        #endregion
        #region C'tors
        public ChunkedMemoryStream()
        {
            _chunks = new Collection<byte[]> { new byte[BUFFER_LENGTH], new byte[BUFFER_LENGTH] };
            _position = ZERO;
            _length = ZERO;
        }
        #endregion
        #region Instance Properties
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
                if (_position > _length)
                    _position = _length - ONE;
            }
        }
        private byte[] CurrentChunk
        {
            get
            {
                long positionDividedByBufferLength = _position / BUFFER_LENGTH;
                var chunkIndex = Convert.ToInt32(positionDividedByBufferLength);
                byte[] chunk = _chunks[chunkIndex];
                return chunk;
            }
        }
        private int PositionInChunk
        {
            get
            {
                int positionInChunk = Convert.ToInt32(_position % BUFFER_LENGTH);
                return positionInChunk;
            }
        }
        private int RemainingBytesInCurrentChunk
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() > ZERO);
                int remainingBytesInCurrentChunk = CurrentChunk.Length - PositionInChunk;
                return remainingBytesInCurrentChunk;
            }
        }
        #endregion
        #region Instance Methods
        public override void Flush()
        {
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
        private long Capacity
        {
            get
            {
                int numberOfChunks = _chunks.Count;
                long capacity = numberOfChunks * BUFFER_LENGTH;
                return capacity;
            }
        }
        public override void SetLength(long value)
        {
            if (value > _length)
            {
                while (value > Capacity)
                {
                    var item = new byte[BUFFER_LENGTH];
                    _chunks.Add(item);
                }
            }
            else if (value < _length)
            {
                var decimalValue = Convert.ToDecimal(value);
                var valueToBeCompared = decimalValue % BUFFER_LENGTH == ZERO ? Capacity : Capacity - BUFFER_LENGTH;
                //remove data chunks, but leave at least two chunks
                while (value < valueToBeCompared && _chunks.Count > TWO)
                {
                    byte[] lastChunk = _chunks.Last();
                    _chunks.Remove(lastChunk);
                }
            }
            _length = value;
            if (_position > _length - ONE)
                _position = _length == 0 ? ZERO : _length - ONE;
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
                if (Capacity == _position)
                    _chunks.Add(new byte[BUFFER_LENGTH]);
            }
        }
        /// <summary>
        ///     Gets entire content of stream regardless of Position value and return output as byte array
        /// </summary>
        /// <returns>byte array</returns>
        public byte[] ToArray()
        {
            var outputArray = new byte[Length];
            if (outputArray.Length != ZERO)
            {
                long outputPosition = ZERO;
                foreach (byte[] chunk in _chunks)
                {
                    var remainingLength = (Length - outputPosition) > chunk.Length
                                              ? chunk.Length
                                              : Length - outputPosition;
                    Array.Copy(chunk, ZERO, outputArray, outputPosition, remainingLength);
                    outputPosition = outputPosition + remainingLength;
                }
            }
            return outputArray;
        }
        /// <summary>
        ///     Method set Position to first element and write entire stream to another
        /// </summary>
        /// <param name="stream">Target stream</param>
        public void WriteTo(Stream stream)
        {
            Contract.Requires(stream != null);
            Position = ZERO;
            var buffer = new byte[BUFFER_LENGTH];
            int bytesReaded;
            do
            {
                bytesReaded = Read(buffer, ZERO, BUFFER_LENGTH);
                stream.Write(buffer, ZERO, bytesReaded);
            } while (bytesReaded > ZERO);
        }
        #endregion
    }
