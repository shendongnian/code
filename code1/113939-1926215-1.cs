        private static void CreateNodes(ItemCollection nodes)
    {
        using (var tfs = TeamFoundationServerFactory.GetServer("http://tfsserver:8080"))
        {
            var versionControlServer = tfs.GetService(typeof (VersionControlServer)) as VersionControlServer;
            versionControlServer.NonFatalError += OnNonFatalError;
    
            // Create a new workspace for the currently authenticated user.             
            var workspace = versionControlServer.CreateWorkspace("Temporary Workspace", versionControlServer.AuthenticatedUser);
    
            try
            {
                // Check if a mapping already exists.
                var workingFolder = new WorkingFolder("$/testagile", @"c:\tempFolder");
    
                // Create the mapping (if it exists already, it just overides it, that is fine).
                workspace.CreateMapping(workingFolder);
    
                // Go through the folder structure defined and create it locally, then check in the changes.
                CreateFolderStructure(workspace, nodes, workingFolder.LocalItem);
    
                // Check in the changes made.
                workspace.CheckIn(workspace.GetPendingChanges(), "This is my comment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Cleanup the workspace.
                workspace.Delete();
    
                // Remove the temp folder used.
                Directory.Delete("tempFolder", true);
            }
        }
    }
    private static void CreateFolderStructure(Workspace workspace, ItemCollection nodes, string initialPath)
    {
        foreach (RadTreeViewItem node in nodes)
        {
            var newFolderPath = initialPath + @"\" + node.Header;
            Directory.CreateDirectory(newFolderPath);
            workspace.PendAdd(newFolderPath);
            if (node.HasItems)
            {
                CreateFolderStructure(workspace, node.Items, newFolderPath);
            }
        }
    }
