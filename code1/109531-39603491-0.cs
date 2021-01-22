    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Configuration;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.Client;
    using System.IO;
    
    namespace DownloadFolder
    {
        class Program
        {
            static void Main(string[] args)
            {
                string teamProjectCollectionUrl = "http://<YourTFSUrl>:8080/tfs/DefaultCollection";  // Get the version control server
                TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(teamProjectCollectionUrl));
                VersionControlServer vcs = teamProjectCollection.GetService<VersionControlServer>();
                String Sourcepath = args[0]; // The folder path in TFS - "$/<TeamProject>/<FirstLevelFolder>/<SecondLevelFolder>"
                String DestinationPath = args[1]; //The folder in local machine - "C:\MyTempFolder"
                ItemSet items = vcs.GetItems(Sourcepath, VersionSpec.Latest, RecursionType.Full);
                String FolderName = null;
                foreach (Item item in items.Items)
                {
                    String ItemName = Path.GetFileName(item.ServerItem);
                    switch (item.ItemType)
                    {
                        case ItemType.File:                        
                            item.DownloadFile(Path.Combine(DestinationPath, FolderName, ItemName));
                            break;
                        case ItemType.Folder:
                            FolderName = Path.GetFileName(item.ServerItem);
                            Directory.CreateDirectory(Path.Combine(DestinationPath, ItemName));
                            break;
                    }
                }
            }
        }
    }
