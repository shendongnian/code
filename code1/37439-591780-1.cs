    class Program
    {
        static void Main(string[] args)
        {
            const string ldap = "LDAP://your-ldap-server-here";
    
            using (DirectoryEntry conn = new DirectoryEntry(ldap))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(conn))
                {
                    searcher.Filter = "(|(samAccountName=userA)(samAccountName=userB))";
                    searcher.PropertiesToLoad.Add("samAccountName");
                    searcher.PropertiesToLoad.Add("userAccountControl");
    
                    using (SearchResultCollection results = searcher.FindAll())
                    {
                        foreach (SearchResult result in results)
                        {
                            int userAccountControl = Convert.ToInt32(result.Properties["userAccountControl"][0]);
                            string samAccountName = Convert.ToString(result.Properties["samAccountName"][0]);
                            bool disabled = ((userAccountControl & 2) > 0);
    
                            Console.WriteLine("{0} ({1:x}) :: {2}", samAccountName, userAccountControl, disabled);
                        }
                    }
                }
            }
    
            Console.ReadLine();
        }
    }
