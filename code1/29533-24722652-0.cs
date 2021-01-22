   		private void UploadToSharePoint(string p, out string newUrl)  //p is path to file to load
        {
            string siteUrl = "https://myCompany.sharepoint.com/site/";
            //Insert Credentials
            ClientContext context = new ClientContext(siteUrl);
            SecureString passWord = new SecureString();
            foreach (var c in "mypassword") passWord.AppendChar(c);
            context.Credentials = new SharePointOnlineCredentials("myUserName", passWord);
            Web site = context.Web;
            //Get the required RootFolder
            string barRootFolderRelativeUrl = "Shared Documents/foo/bar";
            Folder barFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl);
            //Create new subFolder to load files into
            string newFolderName = baseName + DateTime.Now.ToString("yyyyMMddHHmm");
            barFolder.Folders.Add(newFolderName);
            barFolder.Update();
            //Add file to new Folder
            Folder currentRunFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl + "/" + newFolderName);
            FileCreationInformation newFile = new FileCreationInformation { Content = System.IO.File.ReadAllBytes(@p), Url = Path.GetFileName(@p), Overwrite = true };
            currentRunFolder.Files.Add(newFile);
            currentRunFolder.Update();
            context.ExecuteQuery();
            //Return the URL of the new uploaded file
            newUrl = siteUrl + barRootFolderRelativeUrl + "/" + newFolderName + "/" + Path.GetFileName(@p);
        }
