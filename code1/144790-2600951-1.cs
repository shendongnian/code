        byte[] globalKey = new byte[32];
        byte[] globalIV = new byte[16];
        private void cmdSave_Click(object sender, EventArgs e)
        {
                       
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            
            aes.GenerateIV();
            aes.GenerateKey();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;
            globalKey = aes.Key;
            globalIV = aes.IV;
           
            ICryptoTransform aesEncrypt = aes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(fs, aesEncrypt, CryptoStreamMode.Write);
            richTextBox1.SaveFile(cryptoStream, RichTextBoxStreamType.RichText);
            cryptoStream.Close();
            fs.Close();
            richTextBox1.Clear();
           
        }
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            FileStream openRTF = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            
            aes.Key = globalKey;
            aes.IV = globalIV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;
            
            ICryptoTransform aesDecrypt = aes.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream(openRTF, aesDecrypt, CryptoStreamMode.Read);
            FileInfo fileNFO = new FileInfo(openFile.FileName);
            char[] fileContent = new char[fileNFO.Length];
            
            StreamReader fx = new StreamReader(cryptoStream);
            fx.Read(fileContent, 0, Convert.ToInt32(fileContent.Length));
                                 
            fx.Close();
            cryptoStream.Close();
            richTextBox1.Rtf = new String(fileContent); 
                        
        } 
