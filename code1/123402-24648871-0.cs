    using (BinaryWriter Writer = new BinaryWriter(OutputStream))
    { 
        byte[] Buf = new byte[ChunkSize];
 
        List<int> SourceChunkSizeList = new List<int>();
        List<int> EncryptedChunkSizeList = new List<int>();
 
        int ReadBytes;
        while ((ReadBytes = InputStream.Read(Buf, 0, Buf.Length)) > 0)
        {
            byte[] EncryptedData = Encrypt(Buf, ReadBytes);
            OutputStream.Write(EncryptedData, 0, EncryptedData.Length);
 
            SourceChunkSizeList.Add(ReadBytes);
            EncryptedChunkSizeList.Add(EncryptedData.Length);
        }
 
        foreach (int SourceChunkSize in SourceChunkSizeList)
            Writer.Write(SourceChunkSize);
 
        foreach (int EncryptedChunkSize in EncryptedChunkSizeList)
            Writer.Write(EncryptedChunkSize);
    }
