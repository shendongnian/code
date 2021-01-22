    public bool BelongsToGroup(string computerName, string groupName, string domain)
    {
       PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain);
       ComputerPrincipal computer = ComputerPrincipal.FindByIdentity(domainContext, computerName);
       foreach (Principal result in computer.GetGroups())
       {
          if (result.Name == groupName)
          {
             return true;
          }
       }
      return false;
    }
