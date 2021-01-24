    using System.Diagnostics;
    using System.Text.RegularExpressions;
...
    Regex regex = new Regex("<A>(.*?)<B><BEOF>(.*?)<AEOF>");
    string myString = @"<START><A>message<B><BEOF>UnknownLengthOfText<AEOF><A>message<B><BEOF>some other line of text<AEOF><END>";
    MatchCollection matches = regex.Matches(myString);
    foreach (Match m in matches)
    {
        Debug.WriteLine(m.Groups[1].ToString(), m.Groups[2].ToString());
    }
