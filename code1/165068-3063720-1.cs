    byte[] GetSaltedPasswordHash(string username, string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        // byte[] salt = BitConverter.GetBytes(userId);
        byte[] salt = Encoding.UTF8.GetBytes(username);
        byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);
        SHA1 sha = SHA1.Create();
        return sha.ComputeHash(saltedPassword);
    }
