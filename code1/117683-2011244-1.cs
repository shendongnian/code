        static void Main(string[] args)
                {            
                    string domain = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
                    string dc = GetDC(domain);
                    string ldap = String.Format("LDAP://{0}/{1}", domain, dc);
                    DirectoryEntry e = new DirectoryEntry(ldap);
        
                    DirectorySearcher src = new DirectorySearcher(e, "(objectClass=user)");
                    SearchResultCollection res = src.FindAll();
                    foreach (SearchResult r in res)
                    {
                        DirectoryEntry f = r.GetDirectoryEntry();
                        Console.WriteLine(f.Name + "\t" + f.Properties["msIIS-FTPRoot"].Value + f.Properties["msIIS-FTPDir"].Value);
                    }
                    Console.ReadKey();
                }
    
    private static string GetDC(string domain)
            {
                StringBuilder sb = new StringBuilder(domain);
                sb.Replace(".", ",DC=");
                sb.Insert(0, "DC=");
                return sb.ToString();
            }
