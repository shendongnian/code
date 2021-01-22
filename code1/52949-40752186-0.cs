            string uid = Properties.Settings.Default.uid;
            string pwd = Properties.Settings.Default.pwd;
            using (var context = new PrincipalContext(ContextType.Domain, "YOURDOMAIN", uid, pwd))
            {
                using (UserPrincipal user = new UserPrincipal(context))
                {
                    user.GivenName = "*adolf*";
                    using (var searcher = new PrincipalSearcher(user))
                    {
                        foreach (var result in searcher.FindAll())
                        {
                            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                            Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                            Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                            Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                            Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                            Console.WriteLine("Mail: " + de.Properties["mail"].Value);
                            PrincipalSearchResult<Principal> groups = result.GetGroups();
                            foreach (Principal item in groups)
                            {
                                Console.WriteLine("Groups: {0}: {1}", item.DisplayName, item.Name);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.WriteLine("End");
            Console.ReadLine();
