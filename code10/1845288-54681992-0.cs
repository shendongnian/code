    Web web = clientContext.Web;
                    Folder folder = web.GetFolderByServerRelativeUrl("/sites/TST/MyDoc4/Folder");
                    var files = folder.Files;                
                    clientContext.Load(files);
                    clientContext.ExecuteQuery();
