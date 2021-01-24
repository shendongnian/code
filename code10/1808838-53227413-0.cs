    public static string GetAndFixAnchor(string articleBody, string articleWikiCheck) {
        if (articleWikiCheck == "id|wpTextbox1")
        {
            return Regex.Replace(articleBody, @"<a\s+href=""([^""]+)"">([^<]+)", "[$1 $2]");
        }
        else
        {
            // Helpers.ReturnMessage(articleBody); // Uncomment if it is necessary
            return articleBody;
        }
    }
