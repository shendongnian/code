    string input = "#lol test";
    string channel = "";
    string key = "";
    if (input.Contains(" "))
    {   
        string[] split = input.Split(' ');
        channel = split[0];
        key = split[1];
    }
    else
    {
        channel = input;
    }
    Console.WriteLine("Chan: {0}, Key: {1}", channel, key);
