    [StructLayout( LayoutKind.Explicit)]
    public struct MyStruct
    {
        public MyStruct(byte[] buffer)
        {
            if (buffer.Length != 10)
                throw new ArgumentOutOfRangeException();
            High = BitConverter.ToUInt16(buffer, 0);
            Low = BitConverter.ToUInt64(buffer, 2);
        }
        [FieldOffset(0)]
        public ushort High;  //2 bytes
        [FieldOffset(2)]
        public ulong Low;    //8 bytes
        public byte[] Bytes
        {
            get
            {
                return BitConverter.GetBytes(High)
                    .Concat(BitConverter.GetBytes(Low))
                    .ToArray();
            }
        }
        public override string ToString()
        {
            return Convert.ToBase64String(Bytes);
        }
        public static MyStruct Parse(string toParse)
        {
            var bytes = Convert.FromBase64String(toParse);
            return new MyStruct(bytes);
        }
    }
