    public class ADUser
    {
        public string SamAccountName { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public IEnumerable<ADUser> Get(string username)
        {
            var users = new List<ADUser>();
            var search = new DirectorySearcher(
                new DirectoryEntry("LDAP://domain.com"),
                $"(&(objectClass=user)(objectCategory=person)(sAMAccountName={username}))",
                new [] { "sAMAccountName", "displayName", "title" } //The attributes you want to see
            ) {
                PageSize = 1000 //If you're expecting more than 1000 results, you need this otherwise you'll only get the first 1000 and it'll stop
            };
            using (var results = search.FindAll()) {
                foreach (SearchResult result in results)
                {
                    users.Add(new ADUser
                    {
                        SamAccountName = result.Properties.Contains("sAMAccountName") ? result.Properties["sAMAccountName"][0].ToString() : null,
                        DisplayName = result.Properties.Contains("displayName") ? result.Properties["displayName"][0].ToString() : null,
                        Title = result.Properties.Contains("title") ? result.Properties["title"][0].ToString() : null
                    });
                }
            }
            return users;
        }
    }
