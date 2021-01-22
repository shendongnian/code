    public static string DecodeString(string base64EncodedString)
      {
         byte[] dataToDecode = Convert.FromBase64String(base64EncodedString);
         string result = Encoding.ASCII.GetString(dataToDecode);
         return result;
      }
