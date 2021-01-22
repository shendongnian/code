    using (MemoryStream stream = new MemoryStream())
    {
        using (StreamWriter normalWriter = new StreamWriter(stream))
        using (BinaryWriter binaryWriter = new BinaryWriter(stream))
        {
            foreach(...)
            {
                binaryWriter.Write(number);
                binaryWriter.Flush();
                normalWriter.WriteLine(name); //<~~ easier to read afterward.
                normalWriter.Flush();
            }
        }
    
        return MemoryStream.ToArray();
    }
