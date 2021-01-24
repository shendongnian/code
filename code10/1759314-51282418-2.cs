    sealed class ByteArray
    {
        readonly byte[] _source;
        readonly int _speedIndex;
        readonly Func<byte> _getSpeed;
        public int Length => _source.Length;
        public byte this[int index]
        {
            get
            {
                if (index == _speedIndex)
                {
                    return _getSpeed();
                }
                return _source[index];
            }
            set
            {
                if (index != _speedIndex)
                {
                    _source[index] = value;
                }
            }
        }
        public ByteArray(byte[] source, int speedIndex, Func<byte> getSpeed)
        {
            // validate parameters, null check etc...
            _source = source;
            _speedIndex = speedIndex;
            _getSpeed = getSpeed;
        }
        public static explicit operator byte[] (ByteArray value) => value._source;
    }
