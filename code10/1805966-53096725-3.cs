    public bool HasFile
    {
       get { return _selectedWorkspace.Package.Files != null && _selectedWorkspace.Package.Files.Count > 0; }
    }
    
    public bool HasPlatform
    {
       get { return !string.IsNullOrEmpty(_selectedWorkspace.Package.Platform); }
    }
    
    // Do that for all conditions
