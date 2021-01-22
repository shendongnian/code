    using System.Text.RegularExpressions;
    // snip
    string s = "foo\\nbar";
    Regex r = new Regex("\\\\[rnt\\\\]");
    s = r.Replace(s, ReplaceControlChars); ;
    // /snip
    string ReplaceControlChars(Match m)
    {
        switch (m.ToString()[1])
        {
            case 'r': return "\r";
            case 'n': return "\n";
            case '\\': return "\\";
            case 't': return "\t";
            // some control character we don't know how to handle
            default: return m.ToString();
        }
    }
