    string numbers = "User 1, User 2, User 3";
    List<char> noNumbers = new List<char>();
    foreach (var c in numbers)
    {
        if (!char.IsDigit(c))
            noNumbers.Add(c);
    }
    string result = string.Join("", noNumbers);
