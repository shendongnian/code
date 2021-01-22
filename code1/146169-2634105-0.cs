    class BitStream
    {
        private List<byte> _bytes;
        public BitStream()
        {
            _bytes = new List<byte>();
            _bytes.Add(0);
        }
        public byte[] Data
        {
            get { return _bytes.ToArray(); }
        }
        public void Insert(int index, int value)
        {
            if (value < 0)
                value *= -1;
            int bit = value % 2;
            byte bitmask = GetBitmask(index, bit);
            // perform the right-shift operation
            int active_byte = index / 8;
            bool padded = PadIfNecessary();
            int i;
            if (padded)
                i = _bytes.Count - 2;
            else
                i = _bytes.Count - 1;
            for ( ; i > active_byte; --i)
            {
                _bytes[i] = (byte)(_bytes[i] << 1);
                // carry from earlier byte if necessary
                if ((_bytes[i - 1] & 128) == 128)
                    _bytes[i] |= 1;
            }
            // now shift within the target byte
            _bytes[active_byte] = ShiftActiveByte(_bytes[active_byte], index);
            _bytes[active_byte] |= GetBitmask(index, bit);
        }
        protected byte ShiftActiveByte(byte b, int index)
        {
            index = index % 8;
            byte low_mask = 0;
            byte high_mask = 255;
            for (int i=0; i<index; ++i)
            {
                low_mask = (byte)((low_mask << 1) | 1);
                high_mask = (byte)(high_mask << 1);
            }
            byte low_part = (byte)(b & low_mask);
            byte high_part = (byte)(b & high_mask);
            high_part <<= 1;
            return (byte)(low_part | high_part);
        }
        protected byte GetBitmask(int index, int value)
        {
            return (byte)(value << (index % 8));
        }
        protected bool PadIfNecessary()
        {
            if ((_bytes[_bytes.Count - 1] & 128) == 128)
            {
                _bytes.Add(1);
                return true;
            }
            else return false;
        }
    }
