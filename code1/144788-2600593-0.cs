            private void button1_Click(object sender, EventArgs e)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.GenerateIV();
            aes.GenerateKey();
            aes.Mode = CipherMode.CBC;
            File.WriteAllBytes("Key",aes.Key);
            File.WriteAllBytes("IV",aes.IV);
            ICryptoTransform aesEncrypt = aes.CreateEncryptor();
            using (FileStream fs = new FileStream("file.crypt", FileMode.Create, FileAccess.Write))
            {
                using (CryptoStream cryptoStream = new CryptoStream(fs, aesEncrypt, CryptoStreamMode.Write))
                {
                    richTextBox1.SaveFile(cryptoStream, RichTextBoxStreamType.RichText);
                }
            }
        }
           private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            byte[] AesKey = File.ReadAllBytes("Key");
            byte[] AesIV = File.ReadAllBytes("IV");
            aes.Key = AesKey;
            aes.IV = AesIV;
            ICryptoTransform aesDecrypt = aes.CreateDecryptor();
            using (FileStream openRTF = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read))
            {
                using (CryptoStream cryptoStream = new CryptoStream(openRTF, aesDecrypt, CryptoStreamMode.Read))
                {
                    using (StreamReader fx = new StreamReader(cryptoStream))
                    {
                        richTextBox1.Rtf = fx.ReadToEnd();
                    }
                }
            }
        }
