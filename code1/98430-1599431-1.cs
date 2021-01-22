    public void CopyFile()
    {
        Stream source = HIF.PostedFile.InputStream; //your source file
        Stream destination = File.OpenWrite(filePath); //your destination
        Copy(source, destination);
    }
    public static long Copy(Stream from, Stream to)
    {
        long copiedByteCount = 0;
        byte[] buffer = new byte[2 << 16];
        for (int len; (len = from.Read(buffer, 0, buffer.Length)) > 0; )
        {
            to.Write(buffer, 0, len);
            copiedByteCount += len;
        }
        to.Flush();
        return copiedByteCount;
    }
