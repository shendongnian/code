    var s1 = "Ll";
    var s2 = "m";
    var s3 = "LmD";
    var pattern = "^[LMD]$";
    Console.WriteLine( Regex.IsMatch(s1, pattern, RegexOptions.IgnoreCase) );
    Console.WriteLine( Regex.IsMatch(s2, pattern, RegexOptions.IgnoreCase) );
    Console.WriteLine( Regex.IsMatch(s3, pattern, RegexOptions.IgnoreCase) );
