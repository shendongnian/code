    System.IO.FileStream stream = 
        new FileStream(@"C:\file.pdf", FileMode.CreateNew);
    System.IO.BinaryWriter writer = 
        new BinaryWriter(stream);
    writer.Write(bytes, 0, bytes.Length);
    writer.Close();
