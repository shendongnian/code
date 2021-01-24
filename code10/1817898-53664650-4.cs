    TcpPacket tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
    string rawData = tcpPacket.CustomPrintHex();
    public static class Extensions
    {
        public static string CustomPrintHex(this TcpPacket self)
        {
            byte[] bytes = self.BytesHighPerformance.Bytes;
            // copy / paste of `PrintHex()` with your custom conversion
        }
    }
