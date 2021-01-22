    DirectoryEntry rootEntry = new DirectoryEntry("LDAP://OU=Test OU,DC=test,DC=com");
    DirectorySearcher dsFindOUs = new DirectorySearcher(rootEntry);
    
    dsFindOUs.Filter = "(objectClass=organizationalUnit)";
    dsFindOUs.SearchScope = SearchScope.Subtree;
    SearchResult oResults = dsFindOUs.FindOne();
    DirectoryEntry myOU = oResults.GetDirectoryEntry();
    
    System.Security.Principal.IdentityReference newOwner = new System.Security.Principal.NTAccount("YourDomain", "YourUserName").Translate(typeof(System.Security.Principal.SecurityIdentifier));
    ActiveDirectoryAccessRule newRule = new ActiveDirectoryAccessRule(newOwner, ActiveDirectoryRights.GenericAll, System.Security.AccessControl.AccessControlType.Allow);
    myOU.ObjectSecurity.SetAccessRule(newRule);
