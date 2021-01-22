        private static readonly UTF8Encoding Encoder = new UTF8Encoding();
        public static string Encrypt(string unencrypted)
        {
            if (string.IsNullOrEmpty(unencrypted)) 
                return string.Empty;
            try
            {
                var encryptedBytes = MachineKey.Protect(Encoder.GetBytes(unencrypted));
                if (encryptedBytes != null && encryptedBytes.Length > 0)
                    return HttpServerUtility.UrlTokenEncode(encryptedBytes);    
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }
        public static string Decrypt(string encrypted)
        {
            if (string.IsNullOrEmpty(encrypted)) 
                return string.Empty;
            try
            {
                var bytes = HttpServerUtility.UrlTokenDecode(encrypted);
                if (bytes != null && bytes.Length > 0)
                {
                    var decryptedBytes = MachineKey.Unprotect(bytes);
                    if(decryptedBytes != null && decryptedBytes.Length > 0)
                        return Encoder.GetString(decryptedBytes);
                }
                
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }
