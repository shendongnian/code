    using (MemoryStream msEncrypt = new MemoryStream())
    {
       using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
       {
            //var byteArrayInput = new byte[dataStream.Length];
            //dataStream.Read(byteArrayInput, 0, byteArrayInput.Length);
            //csEncrypt.Write(byteArrayInput, 0, byteArrayInput.Length);
            dataStream.CopyTo(csEncrypt);
            dataStream.Close();
            //result.Cipher = msEncrypt.ToArray();  // not here - not flushed yet
            //msEncrypt.Flush();                    // don't need this
            //msEncrypt.Position = 0;            
        }
        result.Cipher = msEncrypt.ToArray();  
        return result;
    }
   
