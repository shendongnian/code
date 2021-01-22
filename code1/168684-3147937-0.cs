    string input = "10 blah 20 30 nonsense 40 50";
    System.Text.RegularExpressions.Regex.Split(input, @"[^\d.]+");
    { "10", "20", "30", "40", "50" }
    input = "10 blah 20 30 nonsense 40.5 50";
    System.Text.RegularExpressions.Regex.Split(input, @"[^\d.]+");
    { "10", "20", "30", "40.5", "50" }
