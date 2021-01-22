    string text = "RR1234566-001";
    string regex = @"^([A-Z a-z]{2})(\d{7})(\-)(\d+)";
    Match mtch = Regex.Matches(text,regex);
    if (mtch.Success)
    {
        Console.WriteLine(m.Groups[1].Value);    
        Console.WriteLine(m.Groups[2].Value);    
        Console.WriteLine(m.Groups[3].Value);    
        Console.WriteLine(m.Groups[4].Value);    
        return true;
    }
    else
    {
        return false;
    }
