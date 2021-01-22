    public static class StringEncryptor
    {
        private static readonly byte[] key = { 0x45, 0x4E, 0x3A, 0x8C, 0x89, 0x70, 0x37, 0x99, 0x58, 0x31, 0x24, 0x98, 0x3A, 0x87, 0x9B, 0x34 };
        public static string EncryptString(this string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
            {
                return string.Empty;
            }
            var base64String = Base64Encode(sourceString);
            var protectedBytes = ProtectedData.Protect(Convert.FromBase64String(base64String), key, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }
        public static string DecryptString(this string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
            {
                return string.Empty;
            }
            var unprotectedBytes = ProtectedData.Unprotect(Convert.FromBase64String(sourceString), key, DataProtectionScope.CurrentUser);
            var base64String = Convert.ToBase64String(unprotectedBytes);
            return Base64Decode(base64String);
        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
