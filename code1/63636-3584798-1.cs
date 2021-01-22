    string[] words = new string[] { "ab1", "ab2\n", "ab3\n\n", "ab4\r", "ab5\r\n", "ab6\n\r" }; 
    Regex regex = new Regex("^[a-z0-9]+$"); 
    foreach (var word in words) 
    { 
        Console.WriteLine("{0} - {1}", word,
            regex.IsMatch(word,"^[a-z0-9]+$",
                System.Text.RegularExpressions.RegexOptions.Singleline |
                System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace)); 
    }
