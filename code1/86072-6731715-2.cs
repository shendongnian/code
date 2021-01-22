    System.Drawing.Image image = System.Drawing.Image.FromFile("filename");
    byte[] buffer;
    MemoryStream stream = new MemoryStream();
    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
    buffer = stream.ToArray(); // converted to byte array
    stream = new MemoryStream();
    stream.Read(buffer, 0, buffer.Length);
    stream.Seek(0, SeekOrigin.Begin);
    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
