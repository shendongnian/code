        var dir = new DirectoryInfo(path);
        // delete dir in explorer
        System.Diagnostics.Debug.Assert(dir.Exists); // true
        dir.Refresh();
        System.Diagnostics.Debug.Assert(!dir.Exists); // false
