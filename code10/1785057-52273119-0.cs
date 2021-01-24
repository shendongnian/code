    bool CanAccessDirectory(string sDir)
    {
    if (!Directory.Exists(sDir)) return false;
    
    try {
    IEnumerable files = Directory.EnumerateFiles(sDir, "*.*",         SearchOption.AllDirectories);
    }
    catch(UnauthorizedException exc) 
    { return false; } 
    catch(PathtooLongException ex)
    { return false; }
    
    // we reach here
    return true;
    }
