         var workspace = sourceControl .CreateWorkspace("workspaceName","workspaceOwner");
 
            String ServerFolder = @"$/TeamProject/Solution1";
            String LocalFolder = @"D:\Folder\";
 
            WorkingFolder workfolder = new WorkingFolder(ServerFolder,LocalFolder);
            workspace.CreateMapping(workfolder);
 
            workspace.Get();
