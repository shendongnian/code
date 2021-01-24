    public class GameString
    {
        private MemoryStream buf;
        public GameString(string str)
        {
            buf = new MemoryStream();
            // 8 empty bytes at the beginning
            buf.SetLength(8);
            buf.Position = 8;
            Append(str);
        }
        // Different from C++ implementation. This one is public
        // and updates the SetHeader
        public void Append(string str)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(str);
            buf.Write(utf8, 0, utf8.Length);
            SetHeader(1, Length);
        }
        public static GameString operator +(GameString gs, string str)
        {
            gs.Append(str);
            return gs;
        }
        // This one is a property instead of being a method
        public int Length { get => (int)buf.Length - 8; }
        // The char *str ()
        public override string ToString()
        {
            return Encoding.UTF8.GetString(buf.GetBuffer(), 8, (int)buf.Length - 8);
        }
        // This one was missing in the C++ implementation. Returns the internal buffer.
        // trimmed to the correct length. Note that it creates a copy!
        public byte[] ToByteArray()
        {
            return buf.ToArray();
        }
        private void SetHeader(int @ref, int len)
        {
            // This could be optimized. Sadly the GetBytes create new
            // arrays as the return value, instead of writing to a 
            // preexisting array.
            byte[] temp = BitConverter.GetBytes(@ref);
            Buffer.BlockCopy(temp, 0, buf.GetBuffer(), 0, temp.Length);
            temp = BitConverter.GetBytes(len);
            Buffer.BlockCopy(temp, 0, buf.GetBuffer(), 4, temp.Length);
        }
    }
