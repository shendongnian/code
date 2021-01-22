    using (var reader as new System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read))
    {
        using (var md5 as new System.Security.Cryptography.MD5CryptoServiceProvider())
        {
            md5.ComputeHash(reader);
            byte[] hash = nd5.Hash;
        }
    }
