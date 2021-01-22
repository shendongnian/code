        public struct VariableLength
        {
            // Variable Length byte array to int
            public VariableLength(byte[] bytes)
            {
                int index = 0;
                int value = 0;
                byte b;
                do
                {
                    value = (value << 7) | ((b = bytes[index]) & 0x7F);
                    index++;
                } while ((b & 0x80) != 0);
                Length = index;
                Value = value;
                Bytes = new byte[Length];
                Array.Copy(bytes, 0, Bytes, 0, Length);
            }
            // Variable Length int to byte array
            public VariableLength(int value)
            {
                Value = value;
                byte[] bytes = new byte[4];
                int index = 0;
                int buffer = value & 0x7F;
                while ((value >>= 7) > 0)
                {
                    buffer <<= 8;
                    buffer |= 0x80;
                    buffer += (value & 0x7F);
                }
                while (true)
                {
                    bytes[index] = (byte)buffer;
                    index++;
                    if ((buffer & 0x80) > 0)
                        buffer >>= 8;
                    else
                        break;
                }
                Length = index;
                Bytes = new byte[index];
                Array.Copy(bytes, 0, Bytes, 0, Length);
            }
            // Number of bytes used to store the variable length value
            public int Length { get; private set; }
            // Variable Length Value
            public int Value { get; private set; }
            // Bytes representing the integer value
            public byte[] Bytes { get; private set; }
        }
