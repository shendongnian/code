    string regex = @"app_major:(?<major>\d+).*app_minor:(?<minor>\d+).*app_micro:(?<micro>\d+";
    System.Text.RegularExpressions.RegexOptions options =        
       (System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | 
       System.Text.RegularExpressions.RegexOptions.Singleline | 
       System.Text.RegularExpressions.RegexOptions.Multiline   | 
       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
    Regex reg = new Regex(regex, options);
    
    Match match = reg.Matches(yourString);
    string major = match.Groups[1].Value
    string minor = match.Groups[2].Value
    string micro = match.Groups[3].Value
