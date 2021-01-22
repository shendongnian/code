    using (Stream s = File.OpenRead(PathName))
    {
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = CryptoKey;
        rm.IV = CryptoIV;
        using (CryptoStream cs = new CryptoStream(s, rm.CreateDecryptor(), CryptoStreamMode.Read))
        {
            using (GZipStream gs = new GZipStream(cs, CompressionMode.Decompress))
            {
                BinaryFormatter bf = new BinaryFormatter();
                _instance = (Storage)bf.Deserialize(gs);
            }
        }
    }
