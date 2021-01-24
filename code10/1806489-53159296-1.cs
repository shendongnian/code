    public async Task<FileData> UploadFileAsync(Guid id, string name, Stream file)
    {
        int chunckSize = 2097152; //2MB
        int totalChunks = (int)(file.Length / chunckSize);
        if (file.Length % chunckSize != 0)
        {
            totalChunks++;
        }
        for (int i = 0; i < totalChunks; i++)
        {
            long position = (i * (long)chunckSize);
            int toRead = (int)Math.Min(file.Length - position + 1, chunckSize);
            byte[] buffer = new byte[toRead];
            await file.ReadAsync(buffer, 0, buffer.Length);
            using (MultipartFormDataContent form = new MultipartFormDataContent())
            {
                form.Add(new ByteArrayContent(buffer), "files", name);
                form.Add(new StringContent(id.ToString()), "id");
                var meta = JsonConvert.SerializeObject(new ChunkMetaData
                {
                    UploadUid = id.ToString(),
                    FileName = name,
                    ChunkIndex = i,
                    TotalChunks = totalChunks,
                    TotalFileSize = file.Length,
                    ContentType = "application/unknown"
                });
                form.Add(new StringContent(meta), "metaData");
                var response = await Client.PostAsync("/api/Upload", form).ConfigureAwait(false);
                return response.IsSuccessStatusCode;
            }
        }
        return true;
    }
