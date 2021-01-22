    public abstract class MemoryEncoder
    {
        private const int CapacityDelta = 16;
        private byte[] _buffer;
        private int _currentByte;
        private int _length;
        protected MemoryEncoder()
        {
            Buffer = new byte[500];
            Length = 0;
            CurrentByte = 0;
        }
        /// <summary>
        ///   The current byte index in the encoding stream.
        ///   This should not need to be modified, under typical usage,
        ///   but can be used to randomly access the encoding region.
        /// </summary>
        public int CurrentByte
        {
            get
            {
                return _currentByte;
            }
            set
            {
                Contract.Requires(value >= 0);
                Contract.Requires(value <= Length);
                _currentByte = value;
            }
        }
        /// <summary>
        ///   Current number of bytes encoded in the buffer.
        ///   This may be less than the size of the buffer (capacity).
        /// </summary>
        public int Length
        {
            get { return _length; }
            private set
            {
                Contract.Requires(value >= 0);
                Contract.Requires(value <= _buffer.Length);
                Contract.Requires(value >= CurrentByte);
                Contract.Ensures(_length <= _buffer.Length);
                _length = value;
            }
        }
        /// <summary>
        /// The raw buffer encapsulated by the encoder.
        /// </summary>
        protected internal Byte[] Buffer
        {
            get { return _buffer; }
            private set
            {
                Contract.Requires(value != null);
                Contract.Requires(value.Length >= _length);
                _buffer = value;
            }
        }
        /// <summary>
        /// Reserve space in the encoder buffer for the specified number of new bytes
        /// </summary>
        /// <param name="bytesRequired">The number of bytes required</param>
        protected void ReserveSpace(int bytesRequired)
        {
            Contract.Requires(bytesRequired > 0);
            Contract.Ensures((Length - CurrentByte) >= bytesRequired);
            //Check if these bytes would overflow the current buffer););
            if ((CurrentByte + bytesRequired) > Buffer.Length)
            {
                //Create a new buffer with at least enough space for the additional bytes required
                var newBuffer = new Byte[Buffer.Length + Math.Max(bytesRequired, CapacityDelta)];
                //Copy the contents of the previous buffer and replace the original buffer reference
                Buffer.CopyTo(newBuffer, 0);
                Buffer = newBuffer;
            }
            //Check if the total length of written bytes has increased
            if ((CurrentByte + bytesRequired) > Length)
            {
                Contract.Assume(CurrentByte + bytesRequired <= _buffer.Length);
                Length = CurrentByte + bytesRequired;
            }
        }
        [ContractInvariantMethod]
        private void GlobalRules()
        {
            Contract.Invariant(_buffer != null);
            Contract.Invariant(_length <= _buffer.Length);
            Contract.Invariant(_currentByte >= 0);
            Contract.Invariant(_currentByte <= _length);
        }
    }
