    private static void DoEncryption2(string original)
    {
       try
       {
    
          using (var myRijndael = new RijndaelManaged())
          {
             myRijndael.GenerateKey();
             myRijndael.GenerateIV();
    
             // Encrypt the string to an array of bytes. 
             var encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);
    
             //Display the original data and the decrypted data.
             Console.WriteLine("Original:   {0}, Encrypted {1}", original, string.Join("", encrypted.Select(b => b.ToString("X2"))));
          }
       }
       catch (Exception e)
       {
          Console.WriteLine("Error: {0}", e.Message);
       }
    }
