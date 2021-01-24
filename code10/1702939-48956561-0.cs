        private static readonly byte[] SALT = new byte[] { 0x26, 0xdc, 0xff, 0x76, 0x76, 0xad, 0xed, 0x7a, 0x64, 0xc5, 0xfe, 0x20, 0xaf, 0x4d, 0x08, 0x3c };
        public static void Encrypt()
        {
            string fileIn = @"C:\tmp.txt";
            string fileOut = @"C:\tmpEnc.txt";
            try
            {
                SymmetricAlgorithm alg = GetAlgorithm();
                using (StreamReader streamIn = new StreamReader(fileIn))
                using (CryptoStream cs = new CryptoStream(streamIn.BaseStream, alg.CreateEncryptor(), CryptoStreamMode.Read))
                using (StreamWriter streamOut = new StreamWriter(fileOut))
                    cs.CopyTo(streamOut.BaseStream);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var stackTrace = ex.StackTrace;
                throw;
            }
        }
        public static void Decrypt()
        {
            string fileIn = @"C:\tmpEnc.txt";
            string fileOut = @"C:\tmpDec.txt";
            try
            {
                SymmetricAlgorithm alg = GetAlgorithm();
                using (StreamReader streamIn = new StreamReader(fileIn))
                using (CryptoStream cs = new CryptoStream(streamIn.BaseStream, alg.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamWriter streamOut = new StreamWriter(fileOut))
                    cs.CopyTo(streamOut.BaseStream);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                var stackTrace = ex.StackTrace;
                throw;
            }
        }
        private static SymmetricAlgorithm GetAlgorithm()
        {
            string Password = "password";  //as i want 
            //Create Key and IV from the password with the SALT 
            Rfc2898DeriveBytes pdf = new Rfc2898DeriveBytes(Password, SALT);
            //Create a symmetric algorithm with Rijndael
            Rijndael alg = Rijndael.Create();
            //alg.Padding = PaddingMode.PKCS7;
            //alg.BlockSize = 128;          
            alg.Mode = CipherMode.ECB;
            alg.Padding = PaddingMode.PKCS7;
            //SET key and IV 
            alg.Key = pdf.GetBytes(32);
            alg.IV = pdf.GetBytes(16);
            //Create a cryptoStream 
            return alg;
        }
