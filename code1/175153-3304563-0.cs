    byte[] info...
    int x;
    string s;
    int y;
    
    using (BinaryReader reader = new BinaryReader(new MemoryStream(info)))
    {
        x = reader.ReadInt32();
        s = reader.ReadString();
        y = reader.ReadInt32();
    }
