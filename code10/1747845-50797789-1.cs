    string s = "This Is Just A Game";
    string result = string.Concat(
        s.Replace(" ", "")
        .OrderBy(char.ToLower)
        .ThenBy(char.IsLower));
    Console.WriteLine(result);
