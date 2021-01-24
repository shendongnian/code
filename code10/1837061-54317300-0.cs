    public string Encrypt(string clearText, Encoding encoding)
    {
      // use supplied encoding to convert clear text to bytes
      byte[] clearBytes = encoding.GetBytes(clearText);
    
      byte[] bt = // insert your encrypt code here...
      // bt bytes are *not* ascii or utf8 or anything else.  If you just
      // use an encoding to convert to text, you won't have good results
      // lets use base64 encoding to get a nice display string representation
      // of the bytes
      return Convert.ToBase64String(bt);
    }
    
    public string Decrypt(string base64EncryptedString, Encoding encoding)
    {
      // decode the base64
      byte[] bt = Convert.FromBase64String(base64EncryptedString);
    
      byte[] decrypted = // insert your decrypt code here
    
      // now we have the original bytes.  Convert back to string using the same
      // encoding we used when encrypting
      return encoding.GetString(decrypted);
    }
    
    
    // Usage:
    var clearText = "Hello World";
    var asciiEncrypted = Encrypt(clearText, Encoding.ASCII);
    var decrypted = Decrypt(clearText, Encoding.ASCII); // MUST USE SAME ENCODING
    
    var utf8Encrypted = Encrypt(clearText, Encoding.UTF8);
    var utf8Decrypted = Decrypt(clearText, Encoding.UTF8);
