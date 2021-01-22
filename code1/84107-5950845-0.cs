    using (Stream s = File.Create(PathName))
    {
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = CryptoKey;
        rm.IV = CryptoIV;
        using (CryptoStream cs = new CryptoStream(s, rm.CreateEncryptor(), CryptoStreamMode.Write))
        {
            using (GZipStream gs = new GZipStream(cs, CompressionMode.Compress))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(gs, _instance);
            }
        }
    }
