        protected void Button1_Click(object sender, EventArgs e)
        {
            string workspaceName = "MyWorkspace";
            string projectPath = @"$/TeamProject"; // the container Project (like a tabel in sql/ or like a folder) containing the projects sources in a collection (like a database in sql/ or also like a folder) from TFS
            string workingDirectory = @"D:\New1";  // local folder where to save projects sources
            TeamFoundationServer tfs = new TeamFoundationServer("http://test-server:8080/tfs/CollectionName", System.Net.CredentialCache.DefaultCredentials);
                                                                // tfs server url including the  Collection Name --  CollectionName as the existing name of the collection from the tfs server 
            tfs.EnsureAuthenticated(); 
            VersionControlServer sourceControl = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
            Workspace[] workspaces = sourceControl.QueryWorkspaces(workspaceName, sourceControl.AuthenticatedUser, Workstation.Current.Name);
            if (workspaces.Length > 0)
            {
                sourceControl.DeleteWorkspace(workspaceName, sourceControl.AuthenticatedUser);
            }
            Workspace workspace = sourceControl.CreateWorkspace(workspaceName, sourceControl.AuthenticatedUser, "Temporary Workspace");
            try
            {
                workspace.Map(projectPath, workingDirectory);
                GetRequest request = new GetRequest(new ItemSpec(projectPath, RecursionType.Full), VersionSpec.Latest);
                GetStatus status = workspace.Get(request, GetOptions.GetAll | GetOptions.Overwrite); // this line doesn't do anything - no failures or errors
            }
            finally
            {
                if (workspace != null)
                {
                    workspace.Delete();
                    Label1.Text = "The Projects have been brought into the Folder  " + workingDirectory;
                }
            }
        }
