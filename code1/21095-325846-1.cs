    var wp = new WindowsPrincipalEx(WindowsIdentity.GetCurrent());
    result = wp.IsInRole(@"domain\role");
    public class WindowsPrincipalEx : IPrincipal
    {
        // Dictionary to store all groups, key = uppercase groupname, value = groupname as entered in AD
        private Dictionary<string,string> completeGroupList = new Dictionary<string,string>();
        // Private vars
        private WindowsIdentity identity;
        private string domain;
        // Identity property
        public IIdentity Identity
        { 
            get { return identity; }
        }
        // Constructor, accepts identity
        public WindowsPrincipalEx(IIdentity identity)
        {
            this.identity = (WindowsIdentity)identity;
            // Find domain name and store it for filtering purposes
            if (identity.Name.Contains('\\'))
                this.domain = identity.Name.Substring(0, identity.Name.IndexOf('\\') + 1);
            // Find all groups this user belongs to, and store the list for later use
            getRoles(completeGroupList);
        }
        public bool IsInRole(string role)
        {
            // Remove domain
            if (role.StartsWith(domain, StringComparison.CurrentCultureIgnoreCase))
                role = role.Substring(domain.Length);
            return completeGroupList.ContainsKey(role.ToUpper());
        }
        private void getRoles(Dictionary<string,string> groupList)
        {
            // Find username and remove domain
            string name = Identity.Name.Replace(domain,"");
            // Find user in AD
            DirectorySearcher search = new DirectorySearcher("(&(sAMAccountName="+name+")(objectCategory=user))");
            search.PropertiesToLoad.Add("memberof");
            SearchResult result = search.FindOne();
            if (result != null)
            {
                // Add all groups to the groupList dictionary
                foreach (string s in result.Properties["memberOf"])
                {
                    string[] elements = s.Split(new char[] { ',' });
                    foreach (string e in elements)
                        if (e.StartsWith("CN=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!groupList.ContainsKey(e.Substring(3).ToUpper()))
                                groupList.Add(e.Substring(3).ToUpper(),e.Substring(3));
                            break;
                        }
                }
            }
            // Scan through all groups found, and find group on group memberships recursevly
            foreach (var ng in groupList.ToArray())
                getRolesInRoles(groupList, ng.Key);
        }
        private void getRolesInRoles(Dictionary<string, string> groupList, string roleName)
        {
            string name = roleName.Replace(domain, "");
            // Find group in AD
            DirectorySearcher search = new DirectorySearcher("(&(cn="+name+")(objectCategory=group))");
            search.PropertiesToLoad.Add("memberof");
            SearchResult result = search.FindOne();
            if (result != null)
            {
                // Add all groups to the groupList dictionary
                foreach (string s in result.Properties["memberOf"])
                {
                    string[] elements = s.Split(new char[] { ',' });
                    foreach (string e in elements)
                        if (e.StartsWith("CN=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!groupList.ContainsKey(e.Substring(3).ToUpper()))
                            {
                                groupList.Add(e.Substring(3).ToUpper(),e.Substring(3));
                                getRolesInRoles(groupList, e.Substring(3));
                            }
                            break;
                        }
                }
            }
        }
    }
