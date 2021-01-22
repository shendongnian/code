    public class CryptoProvider
    {
        private SymmetricAlgorithm _algorithm = new RijndaelManaged();
        public byte[] EncryptData(byte[] data, string password)
        {
            GetKey(password);
            ICryptoTransform encryptor = _algorithm.CreateEncryptor();
            byte[] cryptoData = encryptor.TransformFinalBlock(data, 0, data.Length);
            return cryptoData;
        }
        public byte[] DecryptData(byte[] cryptoData, string password)
        {
            GetKey(password);
            ICryptoTransform decryptor = _algorithm.CreateDecryptor();
            byte[] data = decryptor.TransformFinalBlock(cryptoData, 0, cryptoData.Length);
            return data;
        }
        private void GetKey(string password)
        {
            byte[] salt = new byte[8];
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            int length = Math.Min(passwordBytes.Length, salt.Length);
            for (int i = 0; i < length; i++)
                salt[i] = passwordBytes[i];
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);
            _algorithm.Key = key.GetBytes(_algorithm.KeySize / 8);
            _algorithm.IV = key.GetBytes(_algorithm.BlockSize / 8);
        }
    }
