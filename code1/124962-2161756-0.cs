    string FriendlyURLTitle(string pTitle)
    {
        pTitle = pTitle.Replace(" ", "-");
        pTitle = HttpUtility.UrlEncode(pTitle);
        return Regex.Replace(pTitle, "\%[0-9A-Fa-f]{2}", "");
    }
