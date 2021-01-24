    private object Deserialize(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        using (var gz = new GZipStream(stream, CompressionMode.Decompress))
        using (var streamReader = new StreamReader(gz))
        {
            return JsonConvert.DeserializeObject(streamReader.ReadToEnd());
        }
    }
