    string input = "12 + 15 +11.5+9"; // or get from Console
    string[] inputNumbers = System.Text.RegularExpressions.Regex.Split(input , @"\s*\+\s*");
    
    Dictionary<int, decimal> variable = new Dictionary<int, decimal>();
    
    for (int i = 0; i < inputNumbers.Length; i++)
        variable.Add(i, decimal.Parse(inputNumbers[i]));
    
    // test
    decimal result = variable[0] * variable[1] + variable[2]; // and so on
