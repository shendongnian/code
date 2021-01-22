    using(Stream memstr = new MemoryStream())
    {
        // copy to a memory stream
        byte[] all = new byte[UploadedFileStream.Length];
        UploadedFileStream.Read(all, 0, UploadedFileStream.Length);
        memstr.Write(all, 0, UploadedFileStream.Length);
        memstr.Seek(0, SeekOrigin.Begin);
        using(Graphics g = Graphics.FromStream(memstr))
        {
             // do your img manipulation, or Save it.
        }
    }
