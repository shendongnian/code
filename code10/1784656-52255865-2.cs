    using System.Text.RegularExpressions;
    string test = "32P125";
    
    // 2 integers followed by any upper cased letter, followed by 3 integers.
    Regex regex = new Regex(@"\d{2}[A-Z]\d{3}", RegexOptions.ECMAScript); 
    Match match = regex.Match(test);
    
    if (match.Success)
    {
        //// Valid string   
    }
    else
    {
        //// Invalid string
    }
