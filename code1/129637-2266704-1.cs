    List<string> listRemovableDrivesBefore = GetRemovableDriveList();
    // ...
    List<string> listRemovableDrivesAfter = GetRemovableDriveList();
    List<string> addedDrives = new List<string>();
    foreach (string s in listRemovableDrivesAfter)
    {
        if (!listRemovableDrivesBefore.Contains(s))
            addedDrives.Add(s);
    }
