    string input = "User 04 13\"03";
    var items = Regex.Split(input, @"(?=\d{2}["]\d{2}$)");
    foreach (string item in items)
    {
        Console.WriteLine(item);
    }
    User 04 
    13"03
