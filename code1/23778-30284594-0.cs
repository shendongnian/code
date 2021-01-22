    public static string Combine(params string[] uriParts)
    {
        string uri = string.Empty;
        if (uriParts != null && uriParts.Any())
        {
            char[] trims = new char[] { '\\', '/' };
            uri = (uriParts[0] ?? string.Empty).TrimEnd(trims);
    
            for (int i = 1; i < uriParts.Length; i++)
            {
                uri = string.Format("{0}/{1}", uri.TrimEnd(trims), (uriParts[i] ?? string.Empty).TrimStart(trims));
            }
        }
    
        return uri;
    }
