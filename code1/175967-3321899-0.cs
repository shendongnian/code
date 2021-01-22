    public static List<string> GetUserGroups(string name)
        {
            List<string> groups = new List<string>();
            DirectorySearcher search = new DirectorySearcher("");
            int groupCount;
            int counter;
            string GroupName;
            string DataToWriteGroups;
            search.Filter = "(&(objectClass=user)(SAMAccountName=" + name + "))";
            search.PropertiesToLoad.Add("memberOf");
            SearchResult result = search.FindOne();
            groupCount = result.Properties["memberOf"].Count;
            if (groupCount > 0)
            {
                DataToWriteGroups = "Group(s) Belongs To User - " + name + "";
                for (counter = 0; counter <= groupCount - 1; counter++)
                {
                    GroupName = "";
                    GroupName = (result.Properties["memberOf"][counter].ToString());
                    groups.Add(GroupName);
                }
            }
            return groups;
        }
