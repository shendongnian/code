    public string SearchAndReplace(string input)
    { 
       var openParen = '(';
       var closeParen = ')';
       var hyphen = '-';
       var newChars = input
            .Where(c => c != closeParen)
            .Select(c => c == openParen ? hyphen : c);
       return new string(newChars.ToArray());
    }
