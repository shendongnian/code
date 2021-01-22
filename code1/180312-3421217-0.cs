    public struct SMB_MESSAGE {
        public SMB_PARAMETERS Parameters;
        public SMB_DATA Data;
    }
    public struct SMB_PARAMETERS
    {
        public byte WordCount;
        public ushort[] Words;
    }
    public struct SMB_DATA
    {
        public ushort ByteCount;
        public Bytes Bytes;
    }
    public struct Bytes
    {
        public ushort BufferFormat;
        public byte[] Name;
    }
