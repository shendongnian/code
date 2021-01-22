    public static void EncryptAndSerialize(string filename, MyObject obj, SymmetricAlgorithm key)
    {
        using(FileStream fs = File.Open(filename, FileMode.Create))
        {
            using(CryptoStream cs = new CryptoStream(fs, key.CreateEncryptor(), CryptoStreamMode.Write))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(MyObject));
                xmlser.Serialize(cs, obj); 
            }
        }
    }
