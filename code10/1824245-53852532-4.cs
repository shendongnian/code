    static void Main(string[] args)
            {
                var service = ConnectionToEws.ConnectToService();
                var someFolder = GetFolder(service, "MyFolderName");
                var results = someFolder.FindItems(new ItemView(1));
                foreach (var item in results)
                {
                    var alternatePublicFolderItem = new AlternatePublicFolderItemId(IdFormat.EwsId, someFolder.Id.UniqueId, item.Id.ToString());
                    var convertResult = service.ConvertId(alternatePublicFolderItem, IdFormat.HexEntryId);
                    Console.WriteLine(((AlternatePublicFolderItemId)convertResult).ItemId);
                }
    
                Console.ReadKey();
            }
    
            private static Folder GetFolder(ExchangeService service, string folderName)
            {
                var folderView = new FolderView(int.MaxValue);
                var findFolderResults = service.FindFolders(WellKnownFolderName.PublicFoldersRoot, folderView);
                foreach (var folder in findFolderResults)
                {
                    if (folderName.Equals(folder.DisplayName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return folder;
                    }
                }
                return null;
            }
