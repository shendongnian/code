    var lines = File.ReadAllLines(FileName());
    for (int i = 0; i < lines.Length; i += 2)
    {
        Console.WriteLine($"Player Name: {lines[i]}");
        Console.WriteLine($"Player Average: {lines[i + 1]}");
    }
