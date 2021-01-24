    public string enc(string s)
    {
        return System.Web.HttpUtility.HtmlEncode(s);
    }
    /// <summary>
    /// HTML-encodes a string after replacing its newlines with br tags
    /// </summary>
    public string enc_br(string s)
    {
        if (String.IsNullOrWhiteSpace(s))
            return s;
        var lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        if (lines.Length == 1)
            return enc(lines[0]);
        else
        {
            for (var i = 0; i < lines.Length; ++i)
            {
                lines[i] = enc(lines[i]);
            }
            return String.Join("<br />", lines);
        }
    }
