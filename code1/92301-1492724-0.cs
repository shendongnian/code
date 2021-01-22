    public class Septets
    {
        readonly List<byte> _bytes = new List<byte>();
        private int _currentBit, _currentByte;
        void EnsureSize(int index)
        {
            while (_bytes.Count < index + 1)
                _bytes.Add(0);
        }
        public void Add(bool bitVal)
        {
            EnsureSize(_currentByte);
            if (bitVal)
                _bytes[_currentByte] |= (byte)(1 << _currentBit);
            _currentBit++;
            if (_currentBit == 8)
            {
                _currentBit = 0;
                _currentByte++;
            }
        }
        public void AddSeptet(byte septet)
        {
            for (int n = 0; n < 7; n++)
                Add(((septet & (1 << n)) != 0 ? true : false));
        }
        public void AddSeptets(byte[] septets)
        {
            for (int n = 0; n < septets.Length; n++)
                AddSeptet(septets[n]);
        }
        public byte[] ToByteArray()
        {
            return _bytes.ToArray();
        }
        public static byte[] Pack(byte[] septets)
        {
            var packer = new Septets();
            packer.AddSeptets(septets);
            return packer.ToByteArray();
        }
    }
