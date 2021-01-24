     string[] splittedStr = Regex.Split(Page.ResolveUrl(Request.RawUrl), "(\\D[\\d]+)");
        string newUrl = Page.ResolveUrl(Request.RawUrl);
        newUrl = newUrl.Remove(newUrl.LastIndexOf("/"));
        string urlMarchio = "";
        string urlSottocategoria = "";
        for (int j = 0; j < splittedStr.Length; j++)
        {
            if (splittedStr[j].Contains("S")) urlSottocategoria = splittedStr[j];
            else if (splittedStr[j].Contains("M")) urlMarchio = splittedStr[j];
        }
