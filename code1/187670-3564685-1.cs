    void Main()
    {
        using (FileStream stream = new FileStream(@"c:\temp\test.dat", FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(stream))
            writer.EncodeInt32(123456789);
    
        using (FileStream stream = new FileStream(@"c:\temp\test.dat", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(stream))
            reader.DecodeInt32().Dump();
    }
    
    // Define other methods and classes here
    
    public static class Extensions
    {
        public static void EncodeInt32(this BinaryWriter writer, int value)
        {
            bool first = true;
            while (first || value > 0)
            {
                first = false;
                byte lower7bits = (byte)(value & 0x7f);
                value >>= 7;
                if (value > 0)
                    lower7bits |= 128;
                writer.Write(lower7bits);
            }
        }
    
        public static int DecodeInt32(this BinaryReader reader)
        {
            bool more = true;
            int value = 0;
            int shift = 0;
            while (more)
            {
                byte lower7bits = reader.ReadByte();
                more = (lower7bits & 128) != 0;
                value |= (lower7bits & 0x7f) << shift;
                shift += 7;
            }
            return value;
        }
    }
