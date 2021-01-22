    public static MyObject DecryptAndDeserialize(string filename, SymmetricAlgorithm key)    
    {
        using(FileStream fs = File.Open(filename, FileMode.Open))
        {
            using(CryptoStream cs = new CryptoStream(fs, key.CreateDecryptor(), CryptoStreamMode.Read))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(MyObject));
                return (MyObject) xmlser.Deserialize(cs);
            }
        }
    }
