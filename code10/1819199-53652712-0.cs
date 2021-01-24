    byte[] byteArray = new byte[10];
    using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
    {
        reader.BaseStream.Seek(<seekToPosition>, SeekOrigin.Begin);
        reader.Read(byteArray, 0, <numberOfLinesToRead>);
    }
    string result = System.Text.Encoding.UTF8.GetString(byteArray);
