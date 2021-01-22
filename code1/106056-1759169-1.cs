    public class DataSerializer<T>
    {
      static XmlSerializer _serializer = new XmlSerializer(typeof(T));
      static SymmetricAlgorithm _encryptionAlgorithm;
      public static void SetEncryptionKey(byte[] key)
      {
        _encryptionAlgorithm = Aes.Create();
        _encryptionAlgorithm.Key = key;
      }
      public static void WriteData(string filePath, T data)
      {
        using(var fileStream = File.OpenWrite(filePath))
        {
          var cryptoStream = new CryptoStream(fileStream, _encryptionAlgorithm, CryptoStreamMode.Write);
          _serializer.Serialize(cryptoStream, data);
          cryptoStream.Flush();
        }
      }
      public static T ReadData(string filePath)
      {
        using(var fileStream = File.OpenRead(filePath))
        {
          var cryptoStream = new CryptoStream(fileStream, _encryptionAlgorithm, CryptoStreamMode.Read);
          return (T)_serializer.Deserialize(Stream);
        }
      }
    }
