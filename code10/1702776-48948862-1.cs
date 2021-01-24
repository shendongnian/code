    using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
    using (System.Net.Http.HttpResponseMessage response = await client.GetAsync("http://localhost:53204/ProtobuffToString")) //<= Will call ProtobuffToString() above
    using (System.Net.Http.HttpContent content = response.Content)
    using (var memoryStream = new MemoryStream())
    {
        await content.CopyToAsync(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin); // reset stream
        return ProtoBuf.Serializer.Deserialize<Dictionary<int, decimal>>(memoryStream); // assuming that you return the Dictionary, not a string
    }
