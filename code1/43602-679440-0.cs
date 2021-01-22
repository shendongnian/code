    public struct MyGuid
    {
        public int Data1;
        public short Data2;
        public short Data3;
        public byte[] Data4;
        public MyGuid(Guid g)
        {
            byte[] gBytes = g.ToByteArray();
            Data1 = BitConverter.ToInt32(gBytes, 0);
            Data2 = BitConverter.ToInt16(gBytes, 4);
            Data3 = BitConverter.ToInt16(gBytes, 6);
            Data4 = new Byte[8];
            Buffer.BlockCopy(gBytes, 8, Data4, 0, 8);
        }
        public Guid ToGuid()
        {
            return new Guid(Data1, Data2, Data3, Data4);
        }
    }
