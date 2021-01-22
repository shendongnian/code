    string pattern = @"^[-+\p{L}\p{N}]+$";
    Regex.IsMatch("abc", pattern); // returns true
    Regex.IsMatch("abc123", pattern); // returns true
    Regex.IsMatch("abc123+-", pattern); // returns true
    Regex.IsMatch("abc123+-åäö", pattern); // returns true
    Regex.IsMatch("abc123_", pattern); // returns false
    Regex.IsMatch("abc123+-?", pattern); // returns false
    Regex.IsMatch("abc123+-|", pattern); // returns false
