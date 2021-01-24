    using System.Text.RegularExpressions;
    
    var patternToMatch = "[0-9]{3}card\.json";
    var regex = new Regex(patternToMatch, RegexOptions.IgnoreCase);
    
    if (regex.IsMatch(qnaResult))
    {
        // Do something...
    }
