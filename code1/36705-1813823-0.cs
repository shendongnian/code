        private static IEnumerable<MailItem> readPst(string pstFilePath, string pstName)
        {
            List<MailItem> mailItems = new List<MailItem>();
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            NameSpace outlookNs = app.GetNamespace("MAPI");
            
            // Add PST file (Outlook Data File) to Default Profile
            outlookNs.AddStore(pstFilePath);
            string storeInfo = null;
            foreach (Store store in outlookNs.Stores)
            {
                storeInfo = store.DisplayName;
                storeInfo = store.FilePath;
                storeInfo = store.StoreID;
            }
            MAPIFolder rootFolder = outlookNs.Stores[pstName].GetRootFolder();
            
            // Traverse through all folders in the PST file
            Folders subFolders = rootFolder.Folders;
            foreach (Folder folder in subFolders)
            {
                ExtractItems(mailItems, folder);
            }
            // Remove PST file from Default Profile
            outlookNs.RemoveStore(rootFolder);
            return mailItems;
        }
        private static void ExtractItems(List<MailItem> mailItems, Folder folder)
        {
            Items items = folder.Items;
            int itemcount = items.Count;
            foreach (object item in items)
            {
                if (item is MailItem)
                {
                    MailItem mailItem = item as MailItem;
                    mailItems.Add(mailItem);
                }
            }
            foreach (Folder subfolder in folder.Folders)
            {
                ExtractItems(mailItems, subfolder);
            }
        }
