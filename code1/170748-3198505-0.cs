    public static class StaticStaticDiffieHellman
    {
      private static Aes DeriveKeyAndIv(ECDiffieHellmanCng privateKey, ECDiffieHellmanPublicKey publicKey, byte[] nonce)
      {
        privateKey.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
        privateKey.HashAlgorithm = CngAlgorithm.Sha256;
        privateKey.SecretAppend = nonce;
        byte[] keyAndIv = privateKey.DeriveKeyMaterial(publicKey);
        byte[] key = new byte[16];
        Array.Copy(keyAndIv, 0, key, 0, 16);
        byte[] iv = new byte[16];
        Array.Copy(keyAndIv, 16, iv, 0, 16);
        
        Aes aes = new AesManaged();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        
        return aes;
      }
      
      public static byte[] Encrypt(ECDiffieHellmanCng privateKey, ECDiffieHellmanPublicKey publicKey, byte[] nonce, byte[] data){
        Aes aes = DeriveKeyAndIv(privateKey, publicKey, nonce);
        return aes.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
      }
      
      public static byte[] Decrypt(ECDiffieHellmanCng privateKey, ECDiffieHellmanPublicKey publicKey, byte[] nonce, byte[] encryptedData){
        Aes aes = DeriveKeyAndIv(privateKey, publicKey, nonce);
        return aes.CreateDecryptor().TransformFinalBlock(encryptedData,0, encryptedData.Length);
      }
    }
    // Usage:
    
    ECDiffieHellmanCng key1 = new ECDiffieHellmanCng();    
    ECDiffieHellmanCng key2 = new ECDiffieHellmanCng();
        
    byte[] data = Encoding.UTF8.GetBytes("TestTestTestTes");
    byte[] nonce = Encoding.UTF8.GetBytes("whatever");
        
    byte[] encryptedData = StaticStaticDiffieHellman.Encrypt(key1, key2.PublicKey, nonce, data);
        
    Console.WriteLine(encryptedData.Length); // 16
       
    byte[] decryptedData = StaticStaticDiffieHellman.Decrypt(key2, key1.PublicKey, nonce, encryptedData);
        
    Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
 
