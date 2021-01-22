    var wp = new WindowsPrincipalEx(WindowsIdentity.GetCurrent());
    result = wp.IsInRole(@"domain\role");
    public class WindowsPrincipalEx : IPrincipal
    {
        string[] completeGroupList = null;
        string[] completeGroupListUpperCase = null;
  
        WindowsIdentity identity;
        public IIdentity Identity
        {
            get { return identity; }
        }
        public bool IsInRole(string role)
        {
            if (role.IndexOf('\\') >= 0)
                role = role.Substring(role.IndexOf('\\') + 1);
            return Array.IndexOf(completeGroupListUpperCase, role.ToUpper()) >= 0;
        }
        public WindowsPrincipalEx(IIdentity identity)
        {
            this.identity = (WindowsIdentity)identity;
            // Find all groups this user belongs to
            completeGroupList = getRoles();
            List<string> upper = new List<string>();
            foreach (string l in completeGroupList)
                upper.Add(l.ToUpper());
            completeGroupListUpperCase = upper.ToArray();
        }
        private string [] getRoles()
        {
            string name = Identity.Name;
            if (name.IndexOf('\\')>=0)
                name = name.Substring(name.IndexOf('\\')+1);
            DirectorySearcher search = new DirectorySearcher("(&(sAMAccountName="+name+")(objectCategory=user))"); //"+userName+")");
            search.PropertiesToLoad.Add("memberof");
            List<string> groupsList = new List<string>();
            SearchResult result = search.FindOne();
            if (result != null)
            {
                foreach (string s in result.Properties["memberOf"])
                {
                    string[] elements = s.Split(new char[] { ',' });
                    foreach (string e in elements)
                        if (e.StartsWith("CN=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!groupsList.Contains(e.Substring(3)))
                                groupsList.Add(e.Substring(3));
                            break;
                        }
                }
            }
            foreach (string ng in groupsList.ToArray())
                getRolesInRoles(groupsList, ng);
            return groupsList.ToArray();
        }
        private void getRolesInRoles(List<string> groupsList, string roleName)
        {
            string name = roleName;
            if (name.IndexOf('\\') >= 0)
                name = name.Substring(name.IndexOf('\\') + 1);
            DirectorySearcher search = new DirectorySearcher("(&(cn="+name+")(objectCategory=group))");
            search.PropertiesToLoad.Add("memberof");
            SearchResult result = search.FindOne();
            if (result != null)
            {
                foreach (string s in result.Properties["memberOf"])
                {
                    string[] elements = s.Split(new char[] { ',' });
                    foreach (string e in elements)
                        if (e.StartsWith("CN=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!groupsList.Contains(e.Substring(3)))
                            {
                                groupsList.Add(e.Substring(3));
                                getRolesInRoles(groupsList, e.Substring(3));
                            }
                            break;
                        }
                }
            }
        }
    }
