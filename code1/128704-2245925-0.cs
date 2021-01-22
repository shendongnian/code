    static string Decrypt() {            
      byte[] keyBytes = Convert.FromBase64String("DMF1ucDxtqgxw5niaXcmYQ==");
      byte[] iv = Convert.FromBase64String("GoCeRkrL/EMKNH/BYeLsqQ==");
      byte[] cipherTextBytes = Convert.FromBase64String("UBE3DkgbJgj1K/TISugLxA==");
    
      var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, IV = iv, KeySize = 128, Key = keyBytes, Padding = PaddingMode.Zeros};
    
      using (var decryptor = symmetricKey.CreateDecryptor())
      using (var ms = new MemoryStream(cipherTextBytes))
      using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
        var plainTextBytes = new byte[cipherTextBytes.Length];
        int decryptedByteCount = cs.Read(plainTextBytes, 0, plainTextBytes.Length);
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
      }
    }
