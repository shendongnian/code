    abstract class Packet
    {
        protected enum T
        {
            Byte,
            UInt16,
            UInt32,
            NullPaddedAsciiString,
            Whatever
        }
        protected struct Offset
        {
            public int offset;
            public T type;                      // included only for readability
            public Offset(int i, T type)
            {
                this.type = type;
                offset = i;
            }
        }
        protected byte[] data;
        byte[] RawData { get { return data; } }
        // getters and setters will be implemented using something like this
        protected UInt16 GetUInt16(Offset o)
        {
            // magic
        }
        protected void Write(Offset o, string s)
        { 
            // magic
        }
    }
    class cAuthLogonChallenge : Packet
    {
        // still not perfect, but at least communicates the intent
        static Offset cmd = new Offset(0, T.Byte);
        static Offset error = new Offset(1, T.Byte);
        static Offset size = new Offset(2, T.UInt16);
        // etc.
        public cAuthLogonChallenge(string username)
        {
            var size = 30 + username.Length
            data = new byte[size];
            Write(cmd, 0x00);
            // etc.
        }
    }
