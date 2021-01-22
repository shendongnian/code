    string input = "12345";
    string hex = string.Join(string.Empty,
        input.Select(c => ((int)c).ToString("X")).ToArray());
    
    Console.WriteLine(hex);
