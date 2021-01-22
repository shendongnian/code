    using System.DirectoryServices;
    using System.Linq;
    public string GetUserEmail(string UserId)
        {
    
            var searcher = new DirectorySearcher("LDAP://" + UserId.Split('\\').First().ToLower())
            {
                Filter = "(&(ObjectClass=person)(sAMAccountName=" + UserId.Split('\\').Last().ToLower() + "))"
            };
    
            var result = searcher.FindOne();
            if (result == null)
                return string.Empty;
    
            return result.Properties["mail"][0].ToString();
    
        }
    GetUserEmail(User.Identity.Name) //Get Logged in user email address
