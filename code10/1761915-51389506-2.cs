    Console.WriteLine("There are currently: " + AntiSpam.Count);
    int index;
    string s;
    for(int i=0; i < AntiSpam.Count, i++)
    {
        string[] parts = AntiSpam[i].Split(',');
        username = parts[0];
        Console.WriteLine("Found User: " + username);
        if (parts.Length > 1)
        { 
            index = int.Parse(parts[1])
            AntiSpam[i] = username + "," + (index + 1).ToString();
        }
    }
