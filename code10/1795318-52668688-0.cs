    using (var context = new PrincipalContext(ContextType.Domain, null))
            {
                // Declare array to hold names of groups
                string[] groups = new string[]{"Security Group 1", "group 2", "group 3"};
                // Iterate through each group and perform operation
                foreach (string group in groups){
                    // Notice, your hardcoded group name has been replaced with the group variable
                    using (var group = (GroupPrincipal.FindByIdentity(context, group)))
                    {
                        var users = group.GetMembers(true);
                        foreach (UserPrincipal user in users)
                        {
                            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
                            dt.Rows.Add
                            (
                                Convert.ToString(de.Properties["givenName"].Value),
                                Convert.ToString(de.Properties["sn"].Value),
                                Convert.ToString(de.Properties["mail"].Value),
                                Convert.ToString(de.Properties["department"].Value),
                                Regex.Replace((Convert.ToString(de.Properties["manager"].Value)), @"CN=([^,]*),.*$", "$1")
                            );
                        }
                    }
                }
            }
