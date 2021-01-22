    using(Stream memstr = new MemoryStream())
    {
        // copy to a memory stream
        Stream uploadStream = AsyncFileUpload1.PostedFile.InputStream;
        byte[] all = new byte[uploadStream.Length];
        uploadStream.Read(all, 0, uploadStream.Length);
        memstr.Write(all, 0, uploadStream.Length);
        memstr.Seek(0, SeekOrigin.Begin);
        using(Graphics g = Graphics.FromStream(memstr))
        {
             // do your img manipulation, or Save it.
        }
    }
