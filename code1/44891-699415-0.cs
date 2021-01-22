    string password = "Password";
    string filename = "Filename";
    var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(password));
    hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(filename));
    foreach(byte test in hmacsha256.Hash)
    {
        Console.Write(test.ToString("X2"));
    }
    // 5FE2AE06FF9828B33FE304545289A3F590BFD948CA9AB731C980379992EF41F1
