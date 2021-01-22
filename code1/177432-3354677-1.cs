    string password = GetPasswordFromInput();
    byte[] salt = GetSaltFromDatabase();
    byte[] hash = GetHashFromDatabase();
    using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
    {
        if (deriveBytes.GetBytes(32).SequenceEqual(hash))
            Console.WriteLine("Password matches");
        else
            throw new Exception("Bad password");
    }
