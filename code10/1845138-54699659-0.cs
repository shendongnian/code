        if (!IsSingleProjectItemSelection(out hierarchy, out itemid)) return;
        // Get the file path
        string itemFullPath = null;
        ((IVsProject) hierarchy).GetMkDocument(itemid, out itemFullPath);
        var transformFileInfo = new FileInfo(itemFullPath);    
        string fullPath = transformFileInfo.FullName;
    public static bool IsSingleProjectItemSelection(out IVsHierarchy   hierarchy, out uint itemid)
    {
        hierarchy = null;
        itemid = VSConstants.VSITEMID_NIL;
        int hr = VSConstants.S_OK;
        var monitorSelection = Package.GetGlobalService(typeof(SVsShellMonitorSelection)) as 
        IVsMonitorSelection;
        var solution = Package.GetGlobalService(typeof(SVsSolution)) as IVsSolution;
        if (monitorSelection == null || solution == null)
        {
            return false;
        }        
        IVsMultiItemSelect multiItemSelect = null;
        IntPtr hierarchyPtr = IntPtr.Zero;
        IntPtr selectionContainerPtr = IntPtr.Zero;
        try
        {
            hr = monitorSelection.GetCurrentSelection(out hierarchyPtr, out itemid, out multiItemSelect, out selectionContainerPtr);
            if (ErrorHandler.Failed(hr) || hierarchyPtr == IntPtr.Zero || itemid == VSConstants.VSITEMID_NIL)
            {
            // there is no selection
            return false;
            }
            // multiple items are selected
            if (multiItemSelect != null) return false;
            // there is a hierarchy root node selected, thus it is not a single item inside a project
            if (itemid == VSConstants.VSITEMID_ROOT) return false;
            hierarchy = Marshal.GetObjectForIUnknown(hierarchyPtr) as IVsHierarchy;
            if (hierarchy == null) return false;
            Guid guidProjectID = Guid.Empty;
            if (ErrorHandler.Failed(solution.GetGuidOfProject(hierarchy, out guidProjectID)))
            {
                return false; // hierarchy is not a project inside the Solution if it does not have a ProjectID Guid
            }
            // if we got this far then there is a single project item selected
            return true;
        }
        finally
        {
            if (selectionContainerPtr != IntPtr.Zero)
            {
                Marshal.Release(selectionContainerPtr);
            }
            if (hierarchyPtr != IntPtr.Zero)
            {
                Marshal.Release(hierarchyPtr);
            }
        }
    }
