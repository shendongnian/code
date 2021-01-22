    protected override void OnAfterUninstall(IDictionary savedState)
    {
        base.OnAfterUninstall(savedState);
        string targetDir = Context.Parameters["TargetDir"]; // Must be passed in as a parameter
        
        if (targetDir.EndsWith("|"))
            targetDir = targetDir.Substring(0, targetDir.Length-1);
        if (!targetDir.EndsWith("\\"))
            targetDir += "\\";
        if (!Directory.Exists(targetDir))
        {
            Debug.WriteLine("Target dir does not exist: " + targetDir);
            return;
        }
        string[] files = new[] { "File1.txt", "File2.tmp", "File3.doc" };
        string[] dirs  = new[] { "Logs", "Temp" };
        foreach (string f in files)
        {
            string path = Path.Combine(targetDir, f);
            
            if (File.Exists(path))
                File.Delete(path);
        }
        foreach (string d in dirs)
        {
            string path = Path.Combine(targetDir, d);
            if (Directory.Exists(d))
                Directory.Delete(d, true);
        }
        // At this point, all generated files and directories must be deleted.
        // The installation folder will be removed automatically.
    }
