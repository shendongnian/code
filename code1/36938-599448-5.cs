    public class Packet
    {
        public readonly byte[] Buffer;
        public readonly DateTime Timestamp;
        public Packet(DateTime timestamp, byte[] buffer, int size)
        {
            Timestamp = timestamp;
            Buffer = new byte[size];
            System.Buffer.BlockCopy(buffer, 0, Buffer, 0, size);
        }
    }
