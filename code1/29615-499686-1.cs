    DirectoryEntry deRoot = new DirectoryEntry("LDAP://RootDSE");
    
    if (deRoot != null)
    {
      Console.WriteLine("Default naming context: " + deRoot.Properties["defaultNamingContext"].Value);
      Console.WriteLine("Server name: " + deRoot.Properties["serverName"].Value);
      Console.WriteLine("DNS host name: " + deRoot.Properties["dnsHostName"].Value);
    
      Console.WriteLine();
      Console.WriteLine("Additional properties:");
      foreach (string propName in deRoot.Properties.PropertyNames)
        Console.Write(propName + ", ");
      Console.WriteLine();
    }
