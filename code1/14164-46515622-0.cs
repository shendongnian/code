    string s = "z̽a̎l͘g̈o̓", pattern = @"(?s).(?<=(?:.(?=.*$(?<=((\P{M}\p{C}?\p{M}*)\1?))))*)";
    string s1 = string.Concat(s.Reverse());                          // "☐☐̓ög͘l̎a̽z"  
    string s2 = Microsoft.VisualBasic.Strings.StrReverse(s);         // "o̓g̈l͘a̎̽z"  
    string s3 = string.Concat(StringInfo.ParseCombiningCharacters(s).Reverse()
        .Select(i => StringInfo.GetNextTextElement(s, i)));          // "o̓g̈l͘a̎z̽"  
    string s4 = Regex.Replace(s, pattern, "$2").Remove(s.Length);    // "o̓g̈l͘a̎z̽"  
