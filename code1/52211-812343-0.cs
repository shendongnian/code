    using System.Text.RegularExpressions;
    RegexOptions   options = RegexOptions.None;
    Regex          regex = new Regex(@"\<\!\[CDATA\[(?<text>[^\]]*)\]\]\>", options);
    string         input = @"<![CDATA[<table><tr><td>Approved</td></tr></table>]]>";
    // Check for match
    bool   isMatch = regex.IsMatch(input);
    if( isMatch )
      Match   match = regex.Match(input);
      string   HTMLtext = match.Groups["text"].Value;
    end if
