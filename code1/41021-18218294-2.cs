        private BitArray bitBuffer = new BitArray(new byte[65536]);
        private int bitCount = 0;
        
        
        // Write one int. In my code, this is a byte
        public void write(int b)
        {
            BitArray bA = new BitArray((byte)b);
            int[] pattern = new int[8];
            writeBitArray(bA);            
        }
        // Write one bit. In my code, this is a binary value, and the amount of times
        public void write(int b, int len)
        {
            int[] pattern = new int[len];
            BitArray bA = new BitArray(len);
            for (int i = 0; i < len; i++)
            {
                bA.Set(i, (b == 1));                
            }
            
            writeBitArray(bA);
        }
        
        private void writeBitArray(BitArray bA)
        {
            for (int i = 0; i < bA.Length; i++)
            {
                bitBuffer.Set(bitCount + i, bA[i]);
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
