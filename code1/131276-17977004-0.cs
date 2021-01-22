    DirectoryEntry ouEntry = new DirectoryEntry("LDAP://OU=TestOU,DC=TestDomain,DC=local");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    DirectoryEntry childEntry = ouEntry.Children.Add("CN=TestUser" + i,  "user");
                    childEntry.CommitChanges();
                    ouEntry.CommitChanges();
                    childEntry.Invoke("SetPassword", new object[] { "password" });
                    childEntry.CommitChanges();
                }
                catch (Exception ex)
                {
                }
            }
