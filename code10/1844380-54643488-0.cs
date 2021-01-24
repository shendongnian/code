     static void enumerateFolders(Outlook.Folder folder)  //Checks if there are sub folders inside the Inbox folder.
            {
                Outlook.Folders subfolders = folder.Folders;
                if (subfolders.Count > 0)
                {
                    for (int i = 0; i < subfolders.Count; i++)
                    {
                        Outlook.Folder subFolder = (Outlook.Folder) subfolders[i];  //Solution: type casted
                        iterateMessages(subFolder);
                    }
                }
                else
                {
                    iterateMessages(folder);     //This implements the core functionality of the program. It iterates amongst the emails to retrieve the clearstream attachment.
                }
            }
