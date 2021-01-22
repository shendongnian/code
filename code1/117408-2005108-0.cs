    public string GetSHA256Hash(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    throw new ArgumentException("An empty string value cannot be hashed.");
                }
    
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(s);
                Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
