    public static string CombineUri(params string[] uriParts)
    {
        string uri = string.Empty;
        if (uriParts != null && uriParts.Count() > 0)
        {
            char[] trims = new char[] { '\\', '/' };
            uri = uriParts[0].TrimEnd(trims);
            for (int i = 1; i < uriParts.Count(); i++)
            {
                uri = string.Format("{0}/{1}", uri.TrimEnd(trims), uriParts[i].TrimStart(trims));
            }
        }
        return uri;
    }
