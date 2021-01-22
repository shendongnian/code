    using (BinaryReader reader = new BinaryReader(File.OpenRead("data.txt")))
    {
        string line = null;
        long position = reader.BaseStream.Position;
        while (reader.PeekChar() > -1)
        {
            line = reader.ReadString();
            //parse the name out of the line here...
            Console.WriteLine("{0},{1}", position, line);
            position = reader.BaseStream.Position;
        }
    }
