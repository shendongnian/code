    public static void Transform(string source, string target, ICryptoTransform transf)
    {
        var bufferSize = 65536;
        var buffer = new byte[bufferSize];
    
    
        using (var sourceStream = new FileStream(source, FileMode.Open))
        {
            using (var targetStream = new FileStream(target, FileMode.OpenOrCreate))
            {
                using (CryptoStream cs = new CryptoStream(targetStream, transf, CryptoStreamMode.Write))
                {
                    var bytesRead = 0;
                    do
                    {
                        bytesRead = sourceStream.Read(buffer, 0, bufferSize);
                        cs.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
    
        }
    
    
    }
    
    public static void Enc(string source, byte[] Key, byte[] IV, string target)
    {
        using (var rijAlg = new AesCng())
        {
            rijAlg.Key = Key;
            rijAlg.IV = IV;
            ICryptoTransform encryptor = rijAlg.CreateEncryptor();
            Transform(source, target, encryptor);
        }
    
    }
    public static void Dec(string source, byte[] Key, byte[] IV, string target)
    {
        using (var rijAlg = new AesCng())
        {
            rijAlg.Key = Key;
            rijAlg.IV = IV;
            ICryptoTransform decryptor = rijAlg.CreateDecryptor();
            Transform(source, target, decryptor);
        }
    
    }
     
