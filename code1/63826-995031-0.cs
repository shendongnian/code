    public void Delete(string ouPath, string groupPath)
    {
        if (DirectoryEntry.Exists("LDAP://" + groupPath))
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + ouPath);
                DirectoryEntry group = new DirectoryEntry("LDAP://" + groupPath);
                entry.Children.Remove(group);
                group.CommitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        else
        { 
            Console.WriteLine(path + " doesn't exist"); 
        }
    }
