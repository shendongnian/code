    string numbers = "Ho5w ar7e y9ou3?";
    List<char> noNumList = new List<char>();
    
    foreach (var c in numbers)
    {
        if (!char.IsDigit(c))
            noNumList.Add(c);            
    }
    string noNumbers = string.Join("", noNumList);
