    #region "RSA Encrypt/Decrypt"  
    public string RSAEncrypt(string str, string publicKey)  
    {  
      //---Creates a new instance of RSACryptoServiceProvider---  
      try {  
         RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();  
         //---Loads the public key---  
         RSA.FromXmlString(publicKey);  
         byte[] EncryptedStr = null;  
    
         //---Encrypts the string---  
         EncryptedStr = RSA.Encrypt(ASCII.GetBytes(str), false);  
         //---Converts the encrypted byte array to string---  
         int i = 0;  
         System.Text.StringBuilder s = new System.Text.StringBuilder();  
         for (i = 0; i <= EncryptedStr.Length - 1; i++) {  
             //Console.WriteLine(EncryptedStr(i))  
             if (i != EncryptedStr.Length - 1) {  
                 s.Append(EncryptedStr[i] + " ");  
             } else {  
                 s.Append(EncryptedStr[i]);  
             }  
         }  
    
         return s.ToString();  
       } catch (Exception err) {  
         Interaction.MsgBox(err.ToString());  
       }  
    }  
    
    public string RSADecrypt(string str, string privateKey)  
    {  
      try {  
         //---Creates a new instance of RSACryptoServiceProvider---  
         RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();  
         //---Loads the private key---  
         RSA.FromXmlString(privateKey);  
    
         //---Decrypts the string---  
         byte[] DecryptedStr = RSA.Decrypt(HexToByteArr(str), false);  
         //---Converts the decrypted byte array to string---  
         System.Text.StringBuilder s = new System.Text.StringBuilder();  
         int i = 0;  
         for (i = 0; i <= DecryptedStr.Length - 1; i++) {  
             //Console.WriteLine(DecryptedStr(i))  
             s.Append(System.Convert.ToChar(DecryptedStr[i]));  
         }  
         //Console.WriteLine(s)  
         return s.ToString();  
      } catch (Exception err) {  
         Interaction.MsgBox(err.ToString());  
      }  
    }  
    #endregion 
