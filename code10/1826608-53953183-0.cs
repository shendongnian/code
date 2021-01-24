       ExchangeService Service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
        Service.UseDefaultCredentials = false;
        Service.Credentials = new WebCredentials("yourUserID", "yourPassword");
        
        Mailbox ProdSupportMailbox = new Mailbox("ProdSupport@company.com");
        Service.AutodiscoverUrl("ProdSupport@company.com");
        
        FolderView view = new FolderView(100);
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                view.PropertySet.Add(FolderSchema.DisplayName);
                view.Traversal = FolderTraversal.Deep;
                FindFoldersResults findFolderResults = server.FindFolders(WellKnownFolderName.Root, view);
                //find specific folder
                foreach(Folder f in findFolderResults)
                {
                    //show folderId of the folder "test"
                    if (f.DisplayName == "Test")
                        Console.WriteLine(f.Id);
                }
