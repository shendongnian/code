            static void Main(string[] args)
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://ADServer.example.com","lisa@example.com","!P@ssw0rdG03sH3r3!", AuthenticationTypes.Secure);
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
                {
                    PageSize = int.MaxValue,
                    //                Filter = "(&(mail=LJRTestDistroGroup@example.com))"
                                    Filter = "(&(proxyAddresses=smtp:LJRTestSecurityGroup@example.com))"
                };
    
                searcher.PropertiesToLoad.Add("displayName");
                searcher.PropertiesToLoad.Add("proxyAddresses");
                searcher.PropertiesToLoad.Add("mail");
    
                SearchResultCollection result = searcher.FindAll();
    
                List<string> names = new List<string>();
    
                foreach (SearchResult r in result)
                {
                    Console.WriteLine(r.Properties["displayname"][0].ToString());
                    Console.WriteLine(r.Properties["mail"][0].ToString());
                    Console.WriteLine(r.Properties["proxyAddresses"][0].ToString());
                }
    
            }
