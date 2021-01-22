    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.DirectoryServices;
    
    namespace ADMadness
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectorySearcher search = new DirectorySearcher("LDAP://DC=my,DC=domain,DC=com");
                search.Filter = "(SAMAccountName=MyAccount)";
                search.PropertiesToLoad.Add("lastLogonTimeStamp");
                
    
                SearchResult searchResult = search.FindOne();
                
    
                long lastLogonTimeStamp = long.Parse(searchResult.Properties["lastLogonTimeStamp"][0].ToString());
                DateTime lastLogon = DateTime.FromFileTime(lastLogonTimeStamp);
                
    
                Console.WriteLine("The user last logged on at {0}.", lastLogon);
                Console.ReadLine();
            }
        }
    }
