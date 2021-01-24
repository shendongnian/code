    public string CalculateHash(string filename)
    {
        SHA1CryptoServiceProvider crypt = new SHA1CryptoServiceProvider();
        //MD5CryptoServiceProvider crypt = new MD5CryptoServiceProvider();
        string hash = string.Empty;
        using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            byte[] checksum = crypt.ComputeHash(fs);
            foreach (byte b in checksum)
                hash += b.ToString("X2");
        }
        return(hash);
    }
