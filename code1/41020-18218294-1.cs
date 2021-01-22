        private BitArray bitBuffer = new BitArray(new byte[65536]);
        private int bitCount = 0;
        // b is the value to write, len is the number of times to write it
        public abstract void write(int b, int len)
        {
            for (int i = 0; i < len; i++)
            {
                bitBuffer.Set(bitCount + i, (b == 1));
                bitCount++;
            }
            if (bitCount % 8 == 0)
            {
                BitArray bitBufferWithLength = new BitArray(new byte[bitCount / 8]);                
                byte[] res = new byte[bitBuffer.Count / 8];               
                for (int i = 0; i < bitCount; i++)
                {
                    bitBufferWithLength.Set(i, (bitBuffer[i]));
                }
                bitBuffer.CopyTo(res, 0);
                bitCount = 0;
                base.BaseStream.Write(res, 0, res.Length);                                                
            }           
        }
