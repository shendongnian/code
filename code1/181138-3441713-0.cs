    var sha1 = SHA1Managed.Create();
    
    FileStream fs = \\whatever
    using (var cs = new CryptoStream(fs, sha1, CryptoStreamMode.Read))
    {
        byte[] buf = new byte[16];
        int bytesRead = cs.Read(buf, 0, buf.Length);
        long totalBytesRead = bytesRead;
    
        while (bytesRead > 0 && totalBytesRead <= maxBytesToHash)
        {
            bytesRead = cs.Read(buf, 0, buf.Length);
            totalBytesRead += bytesRead;
        }
    }
    
    byte[] hash = sha1.Hash;
