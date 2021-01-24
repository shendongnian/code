    string password = "hello";
    byte[] salt = Convert.FromBase64String("0CD1HGFdkclqcWG5aV+rvw==");
    int iterations = 1000;
    using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA1))
    {
        Console.WriteLine("UTF-8 / SHA-1");
        Console.Write(Convert.ToBase64String(pbkdf2.GetBytes(16)));
        Console.Write(' ');
        Console.WriteLine(Convert.ToBase64String(pbkdf2.GetBytes(16)));
    }
    using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
    {
        Console.WriteLine("UTF-8 / SHA-2-256");
        Console.Write(Convert.ToBase64String(pbkdf2.GetBytes(16)));
        Console.Write(' ');
        Console.WriteLine(Convert.ToBase64String(pbkdf2.GetBytes(16)));
    }
    byte[] utf16 = Encoding.Unicode.GetBytes(password);
    using (var pbkdf2 = new Rfc2898DeriveBytes(utf16, salt, iterations, HashAlgorithmName.SHA1))
    {
        Console.WriteLine("UTF-16LE / SHA-2-256");
        Console.Write(Convert.ToBase64String(pbkdf2.GetBytes(16)));
        Console.Write(' ');
        Console.WriteLine(Convert.ToBase64String(pbkdf2.GetBytes(16)));
    }
    using (var pbkdf2 = new Rfc2898DeriveBytes(utf16, salt, iterations, HashAlgorithmName.SHA256))
    {
        Console.WriteLine("UTF-16LE / SHA-2-256");
        Console.Write(Convert.ToBase64String(pbkdf2.GetBytes(16)));
        Console.Write(' ');
        Console.WriteLine(Convert.ToBase64String(pbkdf2.GetBytes(16)));
    }
