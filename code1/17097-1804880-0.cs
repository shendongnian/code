    /// <summary>Gets the root domain of any URI</summary>
    /// <param name="uri">URI to get root domain of</param>
    /// <returns>Root domain with TLD</returns>
    public static string GetRootDomain(this System.Uri uri)
    {
        if (uri == null)
            return null;
        string Domain = uri.Host;
        while (System.Text.RegularExpressions.Regex.Matches(Domain, @"[\.]").Count > 1)
            Domain = Domain.Substring(Domain.IndexOf('.') + 1);
        Domain = Domain.Substring(0, Domain.IndexOf('.'));
        return Domain;
    }
