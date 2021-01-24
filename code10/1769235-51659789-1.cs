    if (e.Data.GetData(DataFormats.FileDrop, false) != null)
    {
        string[] DroppedDirectories = (string[]) e.Data.GetData(DataFormats.FileDrop,false);
        List<string> directories = new List<string>();
        foreach(string dir in DroppedDirectories)
        {
            if (dir != null)
                directories.Add(dir);
        }
        // Now loop over the directories list which is guaranteed to have valid string items
    }
