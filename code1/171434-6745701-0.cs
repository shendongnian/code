    using (MemoryStream stream = new MemoryStream())
    {
        using (var writer = StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(credentialsJson);
            writer.Close();
        }
        request.ContentLength = stream.Length;
    }
