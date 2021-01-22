        public List<byte> bitBuffer = new List<byte>();      
        public void WriteBits(int b, int len)
        {
            for (int i = 0; i < len; i++)
            {
                bitBuffer.Add((byte)b);
            }
            
            if (bitBuffer.Count % 8 == 0)
            {
                base.BaseStream.Write(bitBuffer.ToArray(), 0, bitBuffer.ToArray().Length);
                currentBits = 0;
                bitBuffer.Clear();
            }           
        }
