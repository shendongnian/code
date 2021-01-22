    public bool IsProbablyJava(string file)
    {
        using (Stream stream = File.OpenRead(file))
        {
            return stream.ReadByte() == 0xca &&
                   stream.ReadByte() == 0xfe &&
                   stream.ReadByte() == 0xba &&
                   stream.ReadByte() == 0xbe;
        }
    }
