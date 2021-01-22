    using System.Text.RegularExpressions;
    
    Regex myRegex = new Regex("/(^-|[WS])/i)");
    if (coordinate.IsMatch(myRegex))
    {
      neg=1;
    }
