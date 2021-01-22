    string username = "username";
    string domain = "domain";
    
    List<string> emailAddresses = new List<string>();
    
    PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain);
    UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, username);
    
    // Add the "mail" entry
    emailAddresses.Add(user.EmailAddress);
    
    // Add the "proxyaddresses" entries.
    PropertyCollection properties = ((DirectoryEntry)user.GetUnderlyingObject()).Properties;
    foreach (object property in properties["proxyaddresses"])
    {
       emailAddresses.Add(property.ToString());
    }
