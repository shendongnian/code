        public byte ConvertToByte(BitArray bits)
        {
            if (bits.Count > 8)
                throw new ArgumentException("ConvertToByte can only work with a BitArray containing a maximum of 8 values");
            byte result = 0;
            for (byte i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    result |= (byte)(1 << i);
            }
            return result;
        }
