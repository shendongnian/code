    public class CrcB
    {
        const ushort __crcBDefault = 0xffff;
        private static ushort UpdateCrc(byte b, ushort crc)
        {
                byte ch = (byte)(b^(byte)(crc & 0x00ff));
                ch = (byte)(ch ^ (ch << 4));
                return (ushort)((crc >> 8)^(ch << 8)^(ch << 3)^(ch >> 4));
        }
        public static ushort ComputeCrc(byte[] bytes)
        {
                var res = __crcBDefault;
                foreach (var b in bytes)
                        res = UpdateCrc(b, res);
                return (ushort)~res;
        }
    }
