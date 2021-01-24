    string numbers = "User 1, User 2, User 3";
    List<char> noNumList = new List<char>();
    
    foreach (var c in numbers)
    {
        if (!char.IsDigit(c))
            noNumList.Add(c);            
    }
    string noNumbers = string.Join("", noNumList);
