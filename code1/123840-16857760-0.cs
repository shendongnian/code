    private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
    private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
    private const int SaltSize = 128 / 8; // 128 bits
    
    public static string HashPassword(string password)
    {
       byte[] salt;
       byte[] subkey;
       using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
       {
          salt = deriveBytes.Salt;
          subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
       }
    
       byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
       Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
       Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
       return Convert.ToBase64String(outputBytes);
    }
    
    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
       byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
    
       // Wrong length or version header.
       if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
          return false;
    
       byte[] salt = new byte[SaltSize];
       Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
       byte[] storedSubkey = new byte[PBKDF2SubkeyLength];
       Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);
    
       byte[] generatedSubkey;
       using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
       {
          generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
       }
       return storedSubkey.SequenceEqual(generatedSubkey);
    }
