    string password = GetPasswordFromInput();
    using (var deriveBytes = new Rfc2898DeriveBytes(password, 32))  // 32-byte salt
    {
        byte[] salt = deriveBytes.Salt;
        byte[] hash = deriveBytes.GetBytes(32);  // 32-byte hash
        SaveToDatabase(salt, hash);
    }
