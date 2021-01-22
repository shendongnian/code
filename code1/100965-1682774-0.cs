    LdapConnection lc = new LdapConnection("ldap.server.name");
    // Reading the Root DSE can always be done anonymously, but the AuthType
    // must be set to Anonymous when connecting to some directories:
    lc.AuthType = AuthType.Anonymous;
    using (lc)
    {
      // Issue a base level search request with a null search base:
      SearchRequest sReq = new SearchRequest(
        null,
        "(objectClass=*)",
        SearchScope.Base,
        "supportedControl");
      SearchResponse sRes = (SearchResponse)lc.SendRequest(sReq);
      foreach (String supportedControlOID in
        sRes.Entries[0].Attributes["supportedControl"].GetValues(typeof(String)))
      {
        Console.WriteLine(supportedControlOID);
        if (supportedControlOID == "1.2.840.113556.1.4.319")
        {
          Console.WriteLine("PAGING SUPPORTED!");
        }
      }
    }
