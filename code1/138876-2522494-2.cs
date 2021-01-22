    private void CreateWebViewFolders()
    {
        MSOutlook.MAPIFolder root = Folder.GetRootFolder(Application.Session);
        MSOutlook.MAPIFolder webViewFolder = Folder.CreateFolder(root, Properties.Resources.WebViewFolderName);
        webViewFolder.WebViewURL = FolderHomePage.RegisterType(typeof(WebViewControl));
        webViewFolder.WebViewOn = true;
    }
