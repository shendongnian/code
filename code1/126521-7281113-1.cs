    public class PeekableStream : Stream
    {
        private readonly Stream underlyingStream;
        private readonly byte[] lookAheadBuffer;
        private int lookAheadIndex;
        public PeekableStream(Stream underlyingStream, int maxPeekBytes)
        {
            if (!underlyingStream.CanRead)
                throw new ArgumentException("Only readable streams are supported by PeekableStream");
            this.underlyingStream = underlyingStream;
            lookAheadBuffer = new byte[maxPeekBytes];
        }
        public override bool CanRead { get { return true; } }
        public override long Position
        {
            get
            {
                return underlyingStream.Position - lookAheadIndex;
            }
            set
            {
                underlyingStream.Position = value;
                lookAheadIndex = 0;
            }
        }
        public virtual int Peek(byte[] buffer, int offset, int count)
        {
            if (count > lookAheadBuffer.Length)
                throw new ArgumentOutOfRangeException("Peekable size is " + lookAheadBuffer.Length);
            while (lookAheadIndex < count)
            {
                int bytesRead = underlyingStream.Read(lookAheadBuffer, lookAheadIndex, count - lookAheadIndex);
                if (bytesRead == 0) // end of stream reached
                    break;
                
                lookAheadIndex += bytesRead;
            }
            int peeked = Math.Min(count, lookAheadIndex);
            Array.Copy(lookAheadBuffer, 0, buffer, offset, peeked);
            return peeked;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesTakenFromLookAheadBuffer = 0;
            if (count > 0 && lookAheadIndex > 0)
            {
                bytesTakenFromLookAheadBuffer = Math.Min(count, lookAheadIndex);
                Array.Copy(lookAheadBuffer, 0, buffer, offset, bytesTakenFromLookAheadBuffer);
                count -= bytesTakenFromLookAheadBuffer;
                offset += bytesTakenFromLookAheadBuffer;
                lookAheadIndex -= bytesTakenFromLookAheadBuffer;
                if (lookAheadIndex > 0) // move remaining bytes in lookAheadBuffer to front
                    // copying into same array should be fine, according to http://msdn.microsoft.com/en-us/library/z50k9bft(v=VS.90).aspx :
                    // "If sourceArray and destinationArray overlap, this method behaves as if the original values of sourceArray were preserved
                    // in a temporary location before destinationArray is overwritten."
                    Array.Copy(lookAheadBuffer, lookAheadBuffer.Length - bytesTakenFromLookAheadBuffer + 1, lookAheadBuffer, 0, lookAheadIndex);
            }
            return count > 0
                ? bytesTakenFromLookAheadBuffer + underlyingStream.Read(buffer, offset, count)
                : bytesTakenFromLookAheadBuffer;
        }
        public override int ReadByte()
        {
            if (lookAheadIndex > 0)
            {
                lookAheadIndex--;
                byte firstByte = lookAheadBuffer[0];
                if (lookAheadIndex > 0)
                    Array.Copy(lookAheadBuffer, 1, lookAheadBuffer, 0, lookAheadIndex);
                return firstByte;
            }
            else
            {
                return underlyingStream.ReadByte();
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            long ret = underlyingStream.Seek(offset, origin);
            lookAheadIndex = 0;
            return ret;
        }
        // from here, only simple delegations to underlyingStream
        public override void Close() { underlyingStream.Close(); base.Close(); }
        public override bool CanSeek { get { return underlyingStream.CanSeek; } }
        public override bool CanWrite { get { return underlyingStream.CanWrite; } }
        public override bool CanTimeout { get { return underlyingStream.CanTimeout; } }
        public override int ReadTimeout { get { return underlyingStream.ReadTimeout; } set { underlyingStream.ReadTimeout = value; } }
        public override int WriteTimeout { get { return underlyingStream.WriteTimeout; } set { underlyingStream.WriteTimeout = value; } }
        public override void Flush() { underlyingStream.Flush(); }
        public override long Length { get { return underlyingStream.Length; } }
        public override void SetLength(long value) { underlyingStream.SetLength(value); }
        public override void Write(byte[] buffer, int offset, int count) { underlyingStream.Write(buffer, offset, count); }
        public override void WriteByte(byte value) { underlyingStream.WriteByte(value); }
    }
