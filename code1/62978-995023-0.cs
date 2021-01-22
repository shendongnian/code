    /// <summary>
    /// Gets the src from an IMG tag
    /// Assigns proper values to link and name, if the htmlId matches the pattern
    /// </summary>
    /// <param name="htmlTd">Html containing IMG tag</param>
    /// <param name="link">Contains the src contents</param>
    /// <param name="name">Contains img element content</param>
    /// <returns>true if success, false otherwise</returns>
    public static bool TryGetImgDetails(string htmlTd, out string link, out string name)
    {
        link = null;
        name = null;
    
        string pattern = "<img\\s*src\\s*=\\s*(?:\"(?<link>[^\"]*)\"|(?<link>\\S+))\\s*>(?<name>.*)\\s*</img>";
    
        if (Regex.IsMatch(htmlTd, pattern))
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            link = r.Match(htmlTd).Result("${link}");
            name = r.Match(htmlTd).Result("${name}");
            return true;
        }
        else
            return false;
    }
