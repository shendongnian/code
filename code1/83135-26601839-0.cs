        public static byte[] Encrypt(byte[] plain, String key)
        {
            byte[] keyArray = SoapHexBinary.Parse(key).Value;
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.None;
            tdes.IV = new byte[8];
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(plain, 0, plain.Length);
            tdes.Clear();
            return resultArray;
        }
        public static byte[] Decrypt(byte[] cipher, String key)
        {
            byte[] keyArray = SoapHexBinary.Parse(key).Value;
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.None;
            tdes.IV = new byte[8];
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(cipher, 0, cipher.Length);
            tdes.Clear();
            return resultArray;
        }
