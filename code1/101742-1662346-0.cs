    public static void GetPublicFolderList()
    {
        DirectoryEntry entry = new DirectoryEntry("LDAP://sorcogruppen.no");
        DirectorySearcher mySearcher = new DirectorySearcher(entry);
        mySearcher.Filter = "(&(objectClass=publicfolder))";
        // Request the mail attribute only to reduce the ammount of traffic
        // between a DC and the application.
        mySearcher.PropertiesToLoad.Add("mail");
    
        // See Note 1
        //mySearcher.SizeLimit = int.MaxValue;
        // No point in requesting all of them at once, it'll page through
        // all of them for you.
    	mySearcher.PageSize = 100;
        // Wrap in a using so the object gets disposed properly.
        // (See Note 2)
    	using (SearchResultCollection searchResults = mySearcher.FindAll())
    	{
            foreach (SearchResult resEnt in searchResults)
            {
                // Make sure the mail attribute is provided and that there
                // is actually data provided.
                if (resEnt.Properties["mail"] != null
                     && resEnt.Properties["mail"].Count > 0)
			    {
                    string email = resEnt.Properties["mail"][0] as string;
                    if (!String.IsNullOrEmpty(email))
                    {
                        // Do something with the email address
                        // for the public folder.
                    }
                }
            }
        }
    }
