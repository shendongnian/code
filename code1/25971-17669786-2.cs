    public void testdownload(stream input)
    {
        byte[] buffer = new byte[16345];
        using (FileStream fs = new FileStream(this.FullLocalFilePath,
                            FileMode.Create, FileAccess.Write, FileShare.None))
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                 fs.Write(buffer, 0, read);
            }
        }
    }
