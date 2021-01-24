    string str = "id=4 issue=critical level project=ABC group=Group A";
    var prefix = Regex.Matches(str, @"\w+=").ToList();
    var values = Regex.Split(str, @"\w+=").Where(x => !string.IsNullOrEmpty(x)).ToList();
    for (int i = 0; i < prefix.Count; i++)
    {
        Console.WriteLine($"{prefix[i]}{values[i]}");
    }
