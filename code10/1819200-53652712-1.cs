    byte[] byteArray = new byte[10];
    var file = 'path/to/your/file';
    using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
    {
        reader.BaseStream.Seek(<startingPosition>, SeekOrigin.Begin);
        reader.Read(byteArray, 0, <numberOfLinesToRead>);
    }
    string result = System.Text.Encoding.UTF8.GetString(byteArray);
