    public static string GenerateHash(string filePathAndName)
    {
      string hashText = "";
      string hexValue = "";
    
      byte[] fileData = File.ReadAllBytes(filePathAndName);
      byte[] hashData = SHA1.Create().ComputeHash(fileData); // SHA1 or MD5
    
      foreach (byte b in hashData)
      {
        hexValue = b.ToString("X").ToLower(); // Lowercase for compatibility on case-sensitive systems
        hashText += (hexValue.Length == 1 ? "0" : "") + hexValue;
      }
    
      return hashText;
    }
