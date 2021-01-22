     DirectoryEntry ouEntry = new DirectoryEntry("LDAP://OU=TestOU,DC=TestDomain,DC=local");
            for (int i = 3; i < 6; i++)
            {
                try
                {
                    DirectoryEntry childEntry = ouEntry.Children.Add("CN=TestUser" + i, "user");
                    childEntry.CommitChanges();
                    ouEntry.CommitChanges();
                    childEntry.Invoke("SetPassword", new object[] { "password" });
                    childEntry.CommitChanges();
                }
                catch (Exception ex)
                {
                }
            }
