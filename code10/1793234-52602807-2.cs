    for (int i = 0; i < homeWork.attachmentspath.Count; i++)
    {
        Mfdc = new MultipartFormDataContent();
        StorageFile sfs = await StorageFile.GetFileFromPathAsync(homeWork.attachmentspath[i]);
        FileStream fileStream = null;
        byte[] imageByteArray = null;
        using (var stream = await sfs.OpenReadAsync())
        {
            imageByteArray = new byte[stream.Size];
            using (var reader = new DataReader(stream))
            {
                await reader.LoadAsync((uint)stream.Size);
                // Keep reading until we consume the complete stream.
                while (reader.UnconsumedBufferLength > 0)
                {
                    uint bytesToRead = reader.ReadUInt32();
                    reader.ReadBytes(imageByteArray);
                }
            }
        }
