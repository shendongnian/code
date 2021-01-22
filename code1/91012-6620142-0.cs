    # region "Variable Declaration"
    
        static string LOG_FILE = AppDomain.CurrentDomain.BaseDirectory + "Cachecallback.txt";
    #endregion
    #region "Functions"
    public static  string RadioButtonChecked(RadioButton RbYes, RadioButton RbNo)
    {
        string strStatus = "";
        if (RbYes.Checked == true)
        {
            strStatus = "Yes";
        }
        if (RbNo.Checked == true)
        {
            strStatus = "No";
        }
        return strStatus;
    }
        public static string Encrypt(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "CSC";
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            EncryptedData = EncryptedData.Replace("+", "*plus*").Replace("&", "*amp*");
            return EncryptedData;
        }
            
