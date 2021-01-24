    string s = "This Is Just A Game";
    string result = new string(
        s.Replace(" ", "")
        .OrderBy(char.ToLower)
        .ThenBy(char.IsLower)
        .ToArray());
    Console.WriteLine(result);
