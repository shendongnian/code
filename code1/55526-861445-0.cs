       private void RecurseThroughFolders(Outlook.Folder theRootFolder, int depth)
        {
            if ( theRootFolder.DefaultItemType != Outlook.OlItemType.olMailItem ) {
                return;
            }
            Console.WriteLine("{0}", theRootFolder.FolderPath);
            foreach( Object item in theRootFolder.Items ) {
                if (item.GetType() == typeof( Outlook.MailItem )) {
                    Outlook.MailItem mi = (Outlook.MailItem)item;
                    if (mi.Categories.Length > 0) {
                        WriteLinePrefix(depth);
                        Console.WriteLine("  $ {0}", mi.Categories);
                    }
                }
            }
            foreach (Outlook.Folder folder in theRootFolder.Folders) {
                RecurseThroughFolders(folder, depth + 1);
            }
        }
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Outlook.Application olApp = new Outlook.Application();
        Console.WriteLine("Default Profile = {0}", olApp.DefaultProfileName);
        Console.WriteLine("Default Store = {0}", olApp.Session.DefaultStore.DisplayName);
        selectExplorers = this.Application.Explorers;
        selectExplorers.NewExplorer += new Outlook.ExplorersEvents_NewExplorerEventHandler( newExplorer_Event );
        Outlook.Folder theRootFolder  = (Outlook.Folder) olApp.Session.DefaultStore.GetRootFolder();
        RecurseThroughFolders( theRootFolder, 0 );
    }
