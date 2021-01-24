    var buffer = new MemoryStream();   
    var writer = new BinaryWriter(buffer);
    
    writer.Write(a);
    writer.Write(b);
    writer.Write(c);
    writer.Close();    
    byte[] bytes = buffer.ToArray();
