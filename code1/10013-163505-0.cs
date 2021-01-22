    private void getFiles(string path)
    {
        foreach (string s in Array.FindAll(Directory.GetFiles(path, "*", SearchOption.AllDirectories), predicate_FileMatch))
        {
            Debug.Print(s);
        }
    }
    
    private bool predicate_FileMatch(string fileName)
    {
        if (fileName.EndsWith(".mp3"))
            return true;
        if (fileName.EndsWith(".jpg"))
            return true;
        return false;
    }
