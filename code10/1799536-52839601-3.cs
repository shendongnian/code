        // Get the folder we want to add images to
        var context = new ClientContext(sharePointSiteUrl)
        context.Credentials = new SharePointOnlineCredentials(username, password);
        Web web = context.Web;
        context.Load(web, w => w.ServerRelativeUrl);
        context.ExecuteQuery();
        Folder targetFolder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + "/Shared%20Documents/" + nameOfTargerFolder);
        context.ExecuteQuery();
