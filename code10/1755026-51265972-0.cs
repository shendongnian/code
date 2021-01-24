    string str = "Hello :) 1002945";
    string pattern = @"(.).*(\d{4})$";
    Match match = Regex.Match(str, pattern);
    if (match.Success)
    {
        string firstChar = match.Groups[1].Value;
        string lastNumber = match.Groups[2].Value;
        Console.WriteLine("First character : " + firstChar);
        Console.WriteLine("Last number : " + lastNumber);
    }
