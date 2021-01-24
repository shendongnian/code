    const int MaximumChunkSize = 1024000;
    public async Task SaveMyObjectAsync(MyObject largeObject)
    {
        //use fileStream to write the object to disk, 
        // so it does not hold it all in memory at the same time
        using (var stream = new FileStream("LocalStreamFile.json", FileMode.Create))
        {
            //JsonSerializer unable to serialize a large object 
            // without OOM error, so use BinaryFormatter
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, request);
            //return to the start of the stream
            stream.Seek(0, SeekOrigin.Begin);
            using (var content = new MultipartContent())
            {
                var buffer = new byte[MaximumChunkSize];
                while (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                    //add the large object in chunks to the multipart content
                    content.Add(new JsonContent(buffer));
                }
                var response = await _httpClient.PostAsync("myobjects/route/", content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
