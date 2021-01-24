    public class TcpPacketCustom: TcpPacket
    {
        public static int AsciiRangeMin { get; } = 32;
        public static int AsciiRangeMax { get; } = 126;
        public static HashSet<int> AdditionalAsciiCodes { get; } = new HashSet<int> { 10, 13 }; //ascii codes of carriage and new line
        public TcpPacketCustom(ByteArraySegment byteArraySegment) : base(byteArraySegment) { }
        public new string PrintHex()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in this.BytesHighPerformance.Bytes)
            {
                int asciiCode = (int)b;
                if ( ((asciiCode < AsciiRangeMin) || (asciiCode > AsciiRangeMax)) && !AdditionalAsciiCodes.Contains(asciiCode) )
                {
                    stringBuilder.Append(".");
                }
                else
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(new byte[1] { b }));
                }
            }
            return stringBuilder.ToString();
        }
    }
