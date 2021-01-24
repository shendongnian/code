    ldapConnection = new LdapConnection(
                    new LdapDirectoryIdentifier(_hostName, _port),
                    null,
                    AuthType.Basic
                    );
    string searchFilter = String.Format("(&(objectClass=user)(uid={0}))", userName);
    SearchRequest searchRequest = new SearchRequest
                    (_userStore,
                     searchFilter,
                     System.DirectoryServices.Protocols.SearchScope.Subtree,
                     new string[] { "DistinguishedName" });
    var response = (SearchResponse)ldapConnection.SendRequest(searchRequest);
    string userDN = response.Entries[0].Attributes["DistinguishedName"][0].ToString();
