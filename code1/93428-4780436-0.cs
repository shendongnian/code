    DirectoryEntry entry = new DirectoryEntry("LDAP://<COMPANYLDAP>/CN=<Group Name>,OU=something,OU=yep,DC=dev,DC=local");
    DirectorySearcher Dsearch = new DirectorySearcher(entry);
    SearchResult sResultSet = Dsearch.FindOne();
    GetProperty(sResultSet, "member");
     public static void GetProperty(SearchResult searchResult, string PropertyName)
            {
                StringBuilder strb = new StringBuilder();
                if (searchResult.Properties.Contains(PropertyName))
                {
    
                    ResultPropertyValueCollection rc = searchResult.Properties[PropertyName];
                    foreach (string name in rc)
                    {
                        DirectoryEntry entry = new DirectoryEntry("LDAP://<COMPANYLDAP>/" + name);
                        DirectorySearcher Dsearch = new DirectorySearcher(entry);
                        //Dsearch.Filter = name;
                        SearchResult sResultSet = Dsearch.FindOne();
                        strb.AppendLine(GetPropertyvalue(sResultSet, "displayname") + "," + GetPropertyvalue(sResultSet, "mail"));
                    }
    
    
                }
    
                File.WriteAllText(strb.ToString(), "c:\\Users.txt");
            }
