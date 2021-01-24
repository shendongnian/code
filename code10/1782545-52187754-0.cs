    var credentials = new SharePointOnlineCredentials(username, securedPassword);
    private static void Flist3(ICredentials credentials)
        {
            ClientContext clientContext = new ClientContext("SHAREPOINT ADDRESS");
            clientContext.Credentials = credentials;  // passing credentials in case you need to work with Sharepoint Online
            using (clientContext)
            {
                List list = clientContext.Web.Lists.GetByTitle("Document Library Name");
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = @"<View Scope='Recursive'><Query></Query></View>";
                Folder ff = list.RootFolder;
                FolderCollection fcol = list.RootFolder.Folders; // here you will save the folder info inside a Folder Collection list
                List<string> lstFile = new List<string>();
                FileCollection ficol = list.RootFolder.Files;   // here you will save the File names inside a file Collection list 
                // ------informational -------
                clientContext.Load(ff);
                clientContext.Load(list);
                clientContext.Load(list.RootFolder);
                clientContext.Load(list.RootFolder.Folders);
                clientContext.Load(list.RootFolder.Files);
                clientContext.ExecuteQuery();
                Console.WriteLine("Root : " + ff.Name + "\r\n");
                Console.WriteLine(" ItemCount : " + ff.ItemCount.ToString());
                Console.WriteLine(" Folder Count : " + ff.Folders.Count.ToString());
                Console.WriteLine(" File Count : " + ff.Files.Count.ToString());
                Console.WriteLine(" URL : " + ff.ServerRelativeUrl);
                //---------------------------
                //---------Here you iterate through the files and not the folders that are in the root folder ------------
                foreach (ClientOM.File f in ficol)
                {
                    Console.WriteLine("Files Name:" + f.Name);
                }
                //-------- here you will iterate through the folders and the files inside the folders that reside in the root folder----
                foreach (Folder f in fcol)
                {
                    Console.WriteLine("Folder Name : " + f.Name);
                    clientContext.Load(f.Files);
                    clientContext.ExecuteQuery();
                    FileCollection fileCol = f.Files;
                    foreach (ClientOM.File file in fileCol)
                    {
                        lstFile.Add(file.Name);
                        Console.WriteLine(" File Name : " + file.Name);
                    }
}                   
