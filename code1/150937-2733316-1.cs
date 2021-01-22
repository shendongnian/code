    public void MoveTo(string destFileName)
    {
        if (destFileName == null)
        {
            throw new ArgumentNullException("destFileName");
        }
        if (destFileName.Length == 0)
        {
            throw new ArgumentException(Environment.GetResourceString("Argument_EmptyFileName"), "destFileName");
        }
        new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, new string[] { base.FullPath }, false, false).Demand();
        string fullPathInternal = Path.GetFullPathInternal(destFileName);
        new FileIOPermission(FileIOPermissionAccess.Write, new string[] { fullPathInternal }, false, false).Demand();
        if (!Win32Native.MoveFile(base.FullPath, fullPathInternal))
        {
            __Error.WinIOError();
        }
        base.FullPath = fullPathInternal;
        base.OriginalPath = destFileName;
        this._name = Path.GetFileName(fullPathInternal);
        base._dataInitialised = -1;
    }
 
