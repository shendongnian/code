    if(password.Length < 8)
    {
        Console.WriteLine("Password length should be 8 symbols or more.");
    }
    if(!password.Any(char.IsUpper))
    {
        Console.WriteLine("Password should contain at least one uppercase letter.");
    }
    if(!password.Any(char.IsLower))
    {
        Console.WriteLine("Password should contain at least one lowercase letter.");
    
    }
    if(!password.Any(char.IsDigit))
    {
        Console.WriteLine("Password should contain at least one digit.");
    }
