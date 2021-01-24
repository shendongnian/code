    using (var memoryStream = new MemoryStream())
    {
        // Copy your file into memoryStream
        memoryStream.Position = 0;
        var fileContent = new ByteArrayContent(memoryStream.ToArray());
        var multiContent = new MultipartFormDataContent {{fileContent, "File", "Blah.pdf"}};
        foreach (var pair in nameValues)
        {
            multiContent.Add(new StringContent(pair.Value), pair.Key);
        }
        return await httpClient.PostAsync(requestUri, multiContent);
    }
