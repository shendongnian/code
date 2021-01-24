    // VERY SIMPLE BigEndianReader class
    public class BigEndianReader
    {
        private Stream _stream;
    
        public BigEndianReader(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new ArgumentException(nameof(stream));
            _stream = stream;
        }
        public byte ReadByte()
        {
            int b = _stream.ReadByte();
            if (b < 0) throw new EndOfStreamException();
            return (byte)b;
        }
    
        public UInt16 ReadUInt16()
        {
            UInt16 v = 0;
            for (int i = 0; i < sizeof(UInt16); i++){v <<= 8;v |= ReadByte();}
            return v;
        }
    
        public UInt32 ReadUInt32()
        {
            UInt32 v = 0;
            for (int i = 0; i < sizeof(UInt32); i++){v <<= 8;v |= ReadByte();}
            return v;
        }
    
        public UInt64 ReadUInt64()
        {
            UInt64 v = 0;
            for (int i = 0; i < sizeof(UInt64); i++) { v <<= 8; v |= ReadByte(); }
            return v;
        }
    }
    
    class MyPacket
    {
        public Byte Address { get; private set; }
        public Byte FunctionCode { get; private set; }
        public Byte ByteField { get; private set; }
        public UInt32 UInt32Field { get; private set; }
        public UInt64 UInt64Field { get; private set; }
        public UInt16 ErrorCode { get; private set; }
    
        public static bool TryParse(byte[] bytes, out MyPacket result)
        {
            result = null;
    
            try
            {
                BigEndianReader r = new BigEndianReader(new MemoryStream(bytes));
                MyPacket p = new MyPacket();
                p.Address = r.ReadByte();
                p.FunctionCode = r.ReadByte();
                p.ByteField = r.ReadByte();
                p.UInt32Field = r.ReadUInt32();
                p.UInt64Field = r.ReadUInt64();
                p.ErrorCode = r.ReadUInt16();
                result = p;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    static int Main(string[] args)
    {
        // Create a sample frame
        byte[] bytes = new byte[] { 0x0, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19 };
    
        MyPacket packet;
    
        if (MyPacket.TryParse(bytes, out packet))
        {
            // Process packet here...
        }
    
        //==================================================================
        Console.Write("(press any key to exit)");
        Console.ReadKey(true);
        return 0;
    }
