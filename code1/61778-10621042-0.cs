    public static void EncryptAndSerialize<T>(string filename, T obj, string encryptionKey) {
      var key = new DESCryptoServiceProvider();
      var e = key.CreateEncryptor(Encoding.ASCII.GetBytes("64bitPas"), Encoding.ASCII.GetBytes(encryptionKey));
      using (var fs = File.Open(filename, FileMode.Create))
      using (var cs = new CryptoStream(fs, e, CryptoStreamMode.Write))
          (new XmlSerializer(typeof (T))).Serialize(cs, obj);
    }
    
    public static T DecryptAndDeserialize<T>(string filename, string encryptionKey) {
      var key = new DESCryptoServiceProvider();
      var d = key.CreateDecryptor(Encoding.ASCII.GetBytes("64bitPas"), Encoding.ASCII.GetBytes(encryptionKey));
      using (var fs = File.Open(filename, FileMode.Open))
      using (var cs = new CryptoStream(fs, d, CryptoStreamMode.Read))
          return (T) (new XmlSerializer(typeof (T))).Deserialize(cs);
    }
