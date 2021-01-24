    var ad = new PrincipalContext(ContextType.Domain, DOMAIN);
    var u  = new UserPrincipal(ad) {SamAccountName = Environment.UserName};
    using (var search = new PrincipalSearcher(u))
    {
        var user = (UserPrincipal) search.FindOne();
        DirectoryEntry dirEntry = (DirectoryEntry)user.GetUnderlyingObject();
        string dept = dirEntry.Properties["Department"].Value.ToString();
        Console.WriteLine(dept);
    }
