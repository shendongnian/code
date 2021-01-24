    public bool HasFile
    {
       get { return _selectedWorkspace.Package.Files != null && _selectedWorkspace.Package.Files.Count > 0; }
    }
    
    public bool HasPlatform
    {
         get  { return _selectedWorkspace.Package.Platform == null && _selectedWorkspace.Package.Platform == "") }
    }
    
    // Do that for all conditions
