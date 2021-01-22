    public static string Encrypt(string Text, byte[] key, byte[] VectorBytes){
        try{
            byte[] TextBytes = Encoding.UTF8.GetBytes(Text);        
            RijndaelManaged rijKey = new RijndaelManaged();
            rijKey.Mode = CipherMode.CBC; 
            ICryptoTransform encryptor = rijKey.CreateEncryptor(key,VectorBytes); 
            MemoryStream memoryStream = new MemoryStream(); 
            cryptoStream.Write(TextBytes, 0, TextBytes.Length); 
            cryptoStream.FlushFinalBlock(); 
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close(); 
            string cipherText = Convert.ToBase64String(cipherTextBytes); 
            return cipherText;
        } 
        catch (Exception e){
            MessageBox.Show("Falsches Passwort "+ e.Message.ToString());
            string t = "";
            return t;
        }
    }
