    `// Connect to TFS
    TfsTeamProjectCollection _tfs = new TfsTeamProjectCollection(new Uri(tfsUrl));
    VersionControlServer _sourceControl = (VersionControlServer)_tfs.GetService(typeof(VersionControlServer));
    // Creata workspace
    Workspace _workSpace = _sourceControl.CreateWorkspace("test");`
