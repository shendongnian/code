    for (int i = 0; i < homeWork.attachmentspath.Count; i++)
    {
        Mfdc = new MultipartFormDataContent();
        StorageFile sfs = await StorageFile.GetFileFromPathAsync(homeWork.attachmentspath[i]);
        FileStream fileStream = null;
        byte[] imageByteArray = null;
        using (var stream = await sfs.OpenReadAsync())
        {
            //imageByteArray = new byte[stream.Size];
            using (MemoryStream ms = new MemoryStream())
            {
                stream.AsStream().CopyTo(ms);
                imageByteArray= ms.ToArray();
            }
        }
