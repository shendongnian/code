    string text1 = "abc";
    string text2 = "XyZ";
    
    string pattern = @"[xXyYzZJ]+";
    
    bool isMatch1 = Regex.IsMatch(text1, pattern); // false
    bool isMatch2 = Regex.IsMatch(text2, pattern); // true
