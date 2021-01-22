        public static string GenerateKeyHash(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return null;
            if (Password.Length < 1) return null;
            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] ret = new byte[40];
            try
            {
                using (RNGCryptoServiceProvider randomBytes = new RNGCryptoServiceProvider())
                {
                    randomBytes.GetBytes(salt);
                    using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
                    {
                        key = hashBytes.GetBytes(20);
                        Buffer.BlockCopy(salt, 0, ret, 0, 20);
                        Buffer.BlockCopy(key, 0, ret, 20, 20);
                    }
                }
                // returns salt/key pair
                return Convert.ToBase64String(ret);
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (ret != null)
                    Array.Clear(ret, 0, ret.Length);
            } 
        }
        public static bool ComparePasswords(string PasswordHash, string Password)
        {
            if (string.IsNullOrEmpty(PasswordHash) || string.IsNullOrEmpty(Password)) return false;
            if (PasswordHash.Length < 40 || Password.Length < 1) return false;
            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] hash = Convert.FromBase64String(PasswordHash);
            try
            {
                Buffer.BlockCopy(hash, 0, salt, 0, 20);
                Buffer.BlockCopy(hash, 20, key, 0, 20);
                using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
                {
                    byte[] newKey = hashBytes.GetBytes(20);
                    if (newKey != null)
                        if (newKey.SequenceEqual(key))
                            return true;
                }
                return false;
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (hash != null)
                    Array.Clear(hash, 0, hash.Length);
            }
        }
        public static byte[] DecryptData(string Data, byte[] Salt)
        {
            if (string.IsNullOrEmpty(Data)) return null;
            byte[] btData = Convert.FromBase64String(Data);
            try
            {
                return ProtectedData.Unprotect(btData, Salt, DataProtectionScope.CurrentUser);
            }
            finally
            {
                if (btData != null)
                    Array.Clear(btData, 0, btData.Length);
            }
        }
        public static string EncryptData(byte[] Data, byte[] Salt)
        {
            if (Data == null) return null;
            if (Data.Length < 1) return null;
            int len = Data.Length % 2 == 0 ? Data.Length : Data.Length + 1;
            byte[] buffer = new byte[len];
            try
            {
                Buffer.BlockCopy(Data, 0, buffer, 0, Data.Length);
                return System.Convert.ToBase64String(ProtectedData.Protect(buffer, Salt, DataProtectionScope.CurrentUser));
            }
            finally
            {
                if (buffer != null)
                    Array.Clear(buffer, 0, buffer.Length);
            }
        }
