    public static bool Exists(string objectPath)
    {
        bool found = false;
        if (DirectoryEntry.Exists(objectPath))
        {
            found = true;
        }
        return found;
    }
