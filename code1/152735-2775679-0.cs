    byte[] bytes;
    using (var stream = new MemoryStream())
    {
        Code39 code = new Code39("10090");
        code.Paint().Save(stream, ImageFormat.Png);
        bytes = stream.ToArray();
    }
