     using System.DirectoryServices;
        
        public void PrintComputersInDomain (string domainName)
        {
            DirectoryEntry de = new DirectoryEntry ("LDAP://" + domainName);
            de.Children.SchemaFilter.Add ("computer");
            foreach (DirectoryEntry c in de.Children)
            {
                Console.WriteLine (c.Name);
            }
        }
