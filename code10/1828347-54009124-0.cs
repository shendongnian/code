    List<string> urlList = IndirizziProtocolliSQL.GetListaIndirizziSiti(dbConfig);
    
    foreach (string currentUrl in urlList)
    {
        Debug.Print("Current url: " + currentUrl);
    
        SPSecurity.RunWithElevatedPrivileges(delegate ()
        {
            using (SPSite oSiteCollection = new SPSite(currentUrl))
            {
                # Gets the collection of all users that belong to the site collection.
                SPUserCollection users = oSiteCollection.RootWeb.SiteUsers;
            }
        });
    }
