    using System;
    using System.DirectoryServices;
    
    namespace LDAPTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string ldapServer = "LDAP://ldap.forumsys.com:389/dc=example,dc=com";
                string userName = "cn=read-only-admin,dc=example,dc=com";
                string password = "password";
    
                var directoryEntry = new DirectoryEntry(ldapServer, userName, password, AuthenticationTypes.ServerBind);
    
                // Bind to server with admin. Real life should use a service user.
                object obj = directoryEntry.NativeObject;
                if (obj == null)
                {
                    Console.WriteLine("Bind with admin failed!.");
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Bind with admin succeeded!");
                }
    
                // Search for the user first.
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = "(uid=riemann)";
                searcher.PropertiesToLoad.Add("*");
                SearchResult rc = searcher.FindOne();
                // First we should handle user not found.
                // To simplify, skip it and try to bind to the user.
                DirectoryEntry validator = new DirectoryEntry(ldapServer, "uid=riemann,dc=example,dc=com", password, AuthenticationTypes.ServerBind);
                if (validator.NativeObject.Equals(null))
                {
                    Console.WriteLine("Cannot bind to user!");
                }
                else
                {
                    Console.WriteLine("Bind with user succeeded!");
                }
            }
        }
    }
