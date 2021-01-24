        // Connect to TFS
        TfsTeamProjectCollection _tfs = new TfsTeamProjectCollection(new Uri(tfsUrl));
        VersionControlServer _sourceControl = (VersionControlServer)_tfs.GetService(typeof(VersionControlServer));
        // Create workspace
        Workspace _workSpace = _sourceControl.CreateWorkspace("test");
