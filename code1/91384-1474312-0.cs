    using System.DirectoryServices;
 
            DirectoryEntry dirs = new DirectoryEntry("WinNT://" + Environment.MachineName);
            foreach (DirectoryEntry de in dirs.Children)
            {
                if (de.SchemaClassName == "User")
                {
                    Console.WriteLine(de.Name);
                    if (de.Properties["lastlogin"].Value != null)
                    {
                        Console.WriteLine(de.Properties["lastlogin"].Value.ToString());
                    }
                    if (de.Properties["lastlogoff"].Value != null)
                    {
                        Console.WriteLine(de.Properties["lastlogoff"].Value.ToString());
                    }
                }
            }
