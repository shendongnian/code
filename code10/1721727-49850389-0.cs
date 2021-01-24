    public string EncryptData(string imageBytesBase64, string Encryptionkey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            byte[] keyBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] ivBytes = Encoding.UTF8.GetBytes(Encryptionkey.Substring(0, 16));
            int len = keyBytes.Length;
            if (len > ivBytes.Length)
                len = ivBytes.Length;
            Array.Copy(keyBytes, ivBytes, len);
            objrij.Key = keyBytes;
            objrij.IV = ivBytes;
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(imageBytesBase64);
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }
