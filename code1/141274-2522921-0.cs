    string text;
    memoryStream.Position = 0;
    using (TextReader reader = new StreamReader(memoryStream, Encoding.ASCII))
    {
        text = reader.ReadToEnd();
    }
