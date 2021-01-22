    public string LinkQuotedEmailsAndURLs(string email)
    {
        Regex toMarch = new Regex("\"((https?|ftp)?://([\\w+?\\.\\w+])+[^\"]*)\"", RegexOptions.IgnoreCase);
       
        MatchCollection mactches = toMatch.Matches(email);
       
        foreach (Match match in mactches) {
            email = email.Replace(match.Value, "<a href=" + match.Value + ">" + match.Value.Substring(1,match.Value.Length-2) + "</a>");
        }
       
        return email;
    }
