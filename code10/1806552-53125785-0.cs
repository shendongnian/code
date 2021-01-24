    using System.Text.RegularExpressions;
    ...
    // The Regex pattern is any number of capitalized letter followed by a non-word character.
    // You may have to adjust this a bit.
    Regex r = new Regex(@"([A-Z]+\W)+"); 
    string s = "OTHER COMMENTS These are other comments that would be here. Some more comments";
    MatchCollection m = r.Matches(s);
    // Only return the first match if there are any matches.
    if (m.Count > 0)
    {
    	Console.WriteLine(r.Matches(s)[0]);
    }
