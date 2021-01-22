    string input = @"this is some code. the code is in C#? it's great! In ""quotes."" after quotes.";
    string pattern = @"(^|\p{P}\s+)(\w+)";
    
    // compiled for performance (might want to benchmark it for your loop)
    Regex rx = new Regex(pattern, RegexOptions.Compiled);
    
    string result = rx.Replace(input, m => m.Groups[1].Value
                                    + m.Groups[2].Value.Substring(0, 1).ToUpper()
                                    + m.Groups[2].Value.Substring(1));
