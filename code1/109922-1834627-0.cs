       public ushort calculate(byte[] bytes)
        {
            int crc = 0xFFFF; // initial value
            // loop, calculating CRC for each byte of the string
            for (int byteIndex = 0; byteIndex < bytes.Length; byteIndex++)
            {
                ushort bit = 0x80; // initialize bit currently being tested
                for (int bitIndex = 0; bitIndex < 8; bitIndex++)
                {
                    bool xorFlag = ((crc & 0x8000) == 0x8000);
                    crc <<= 1;
                    if (((bytes[byteIndex] & bit) ^ (ushort)0xff) != (ushort)0xff)
                    {
                        crc = crc + 1;
                    }
                    if (xorFlag)
                    {
                        crc = crc ^ 0x1021;
                    }
                    bit >>= 1;
                }
            }
            return (ushort)crc;
        }
