        ClientContext cc = new ClientContext(site);
        // try to use the List object, using the name of the list as the parameter
        List oList = cc.Web.Lists.GetByTitle(listName);
        // pass the credantials!
        cc.Credentials = new System.Net.NetworkCredential(< username >, < password >, < domain >);
        // another option - default NetworkCredentials credantials
        // context.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        // pass the uniq id of the record
        ListItem listItem = oList.GetItemById(id);
        // now you can to this
        // ...............
        listItem["System_x0020_Comment"] = "TestComment";
        listItem.Update();
        cc.ExecuteQuery();
