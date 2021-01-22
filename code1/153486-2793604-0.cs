    class MyBinaryWriter : BinaryWriter
    {
        private Encoding _encoding = Encoding.Default;
        public override void Write(string value)
        {
            byte[] buffer = _encoding.GetBytes(value);
            Write(buffer);
            Write((byte)0);
        }
    }
