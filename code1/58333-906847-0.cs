    /// <summary>
    /// Assigns proper values to link and name, if the htmlId matches the pattern
    /// </summary>
    /// <returns>true if success, false otherwise</returns>
    public static bool TryGetHrefDetails(string htmlTd, out string link, out string name)
    {
        link = null;
        name = null;
    
        string pattern = "<td>\\s*<a\\s*href\\s*=\\s*(?:\"(?<link>[^\"]*)\"|(?<link>\\S+))\\s*>(?<name>.*)\\s*</a>\\s*</td>";
    
        if (Regex.IsMatch(htmlTd, pattern))
        {
            Regex r = new Regex(pattern,  RegexOptions.IgnoreCase | RegexOptions.Compiled);
            link = r.Match(htmlTd).Result("${link}");
            name = r.Match(htmlTd).Result("${name}");
            return true;
        }
        else
            return false;
    }
