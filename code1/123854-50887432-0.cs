        private static bool SlowEquals(byte[] a, byte[] b)
                {
                    uint diff = (uint)a.Length ^ (uint)b.Length;
                    for (int i = 0; i < a.Length && i < b.Length; i++)
                        diff |= (uint)(a[i] ^ b[i]);
                    return diff == 0;
                }
        
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
                {
                    Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
                    pbkdf2.IterationCount = iterations;
                    return pbkdf2.GetBytes(outputBytes);
                }
        
        private static string CreateHash(string value, int salt_bytes, int hash_bytes, int pbkdf2_iterations)
                {
                    // Generate a random salt
                    RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
                    byte[] salt = new byte[salt_bytes];
                    csprng.GetBytes(salt);
        
                    // Hash the value and encode the parameters
                    byte[] hash = PBKDF2(value, salt, pbkdf2_iterations, hash_bytes);
    
                    //You need to return the salt value too for the validation process
                    return Convert.ToBase64String(hash) + ":" + 
                           Convert.ToBase64String(hash);
                }
        
        private static bool ValidateHash(string pureVal, string saltVal, string hashVal, int pbkdf2_iterations)
                {
                    try
                    {
                        byte[] salt = Convert.FromBase64String(saltVal);
                        byte[] hash = Convert.FromBase64String(hashVal);
        
                        byte[] testHash = PBKDF2(pureVal, salt, pbkdf2_iterations, hash.Length);
                        return SlowEquals(hash, testHash);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
