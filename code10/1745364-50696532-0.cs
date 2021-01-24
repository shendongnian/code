     using (var clientContext = new ClientContext("https://xxx.sharepoint.com/sites/xxx"))
                {
                    clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                    Web web = clientContext.Web;
                    clientContext.Load(web, a => a.ServerRelativeUrl);
                    clientContext.ExecuteQuery();
    
    
                    Microsoft.SharePoint.Client.File file = clientContext.Web.GetFileByServerRelativeUrl("/sites/jerrydev/Shared%20Documents/test.png");
                    clientContext.Load(file);
                    clientContext.ExecuteQuery();
                    if (file != null)
                    {
                        FileInformation fileInfo = File.OpenBinaryDirect(clientContext, file.ServerRelativeUrl);
                        clientContext.ExecuteQuery();
    
                        var folderpath = @"c:\downloadfolder";
                        if (!System.IO.Directory.Exists(folderpath))
                        {
                            System.IO.Directory.CreateDirectory(folderpath);
                        }
                        using (var fileStream = new System.IO.FileStream(folderpath + @"\" + file.Name, System.IO.FileMode.Create))
                        {
                            fileInfo.Stream.CopyTo(fileStream);
                        }
                    }
    }
