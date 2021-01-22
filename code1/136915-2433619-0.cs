    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "fillRow")]
    public static IEnumerable getNTGroupMembers(string groupName)
    {
        SearchResult result;
        DirectorySearcher search = new DirectorySearcher();
        search.Filter = String.Format("(cn={0})", groupName);
        search.PropertiesToLoad.Add("member");
        result = search.FindOne();
        ArrayList userNames = new ArrayList();
        if (result != null)
        {
            for (int counter = 0; counter < result.Properties["member"].Count; counter++)
            {
                string st = (string) result.Properties["member"][counter];
                DirectoryEntry gpMemberEntry = new DirectoryEntry(("LDAP://" + st));
                if (!(gpMemberEntry == null))
                {
                    PropertyCollection userProps = gpMemberEntry.Properties;
                    object objUser = userProps["sAMAccountname"].Value;
                    userNames.Add(objUser);
                }
            }
        }
        return userNames;
    }
    private static void fillRow(Object obj, out string user)
    {
        object row = (object)obj;
        user = (string)row;
    }
