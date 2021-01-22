    [CLSCompliant(false)]
    public class Crc32 {
        uint[] table = new uint[256];
        uint[] Table { get { return table; } }
    
        public Crc32() {
            MakeCrcTable();
        }
        void MakeCrcTable() {
            for (uint n = 0; n < 256; n++) {
                uint value = n;
                for (int i = 0; i < 8; i++) {
                    if ((value & 1) != 0)
                        value = 0xedb88320 ^ (value >> 1);
                    else
                        value = value >> 1;
                }
                Table[n] = value;
            }
        }
        public uint UpdateCrc(uint crc, byte[] buffer, int length) {
            uint result = crc;
            for (int n = 0; n < length; n++) {
                result = Table[(result ^ buffer[n]) & 0xff] ^ (result >> 8);
            }
            return result;
        }
        public uint Calculate(Stream stream) {
            long pos = stream.Position;
            const int size = 0x32000;
            byte[] buf = new byte[size];
            int bytes = 0;
            uint result = 0xffffffff;
            do {
                bytes = stream.Read(buf, 0, size);
                result = UpdateCrc(result, buf, bytes);
            }
            while (bytes == size);
            stream.Position = pos;
            return ~result;
        }
    }
