    byte[] secondTry;
    using (var ms = new MemoryStream())
    {
        byte[] buffer = new byte[8040]; // sql page size
        int read;
        long offset = 0;
        while ((read = (int)reader.GetBytes(i, offset, buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }
        secondTry = ms.ToArray();
    }
