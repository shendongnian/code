        //Copy the files to the workspace
        File.Copy(_filePath, _testWorkSpacePath, true);
        // Add the files to Pending Changes
        _workSpace.PendAdd(_testWorkSpacePath);
        // Get the conflicts
        var conflitcs =_workSpace.QueryConflicts(new string[] { _workSpaceFilePath }, true);
        // Resolve the conflitcs
        foreach (Conflict conflict in conflitcs)
        {
             conflict.Resolution = Resolution.AcceptYours;
             _workSpace.ResolveConflict(conflict);
        }
