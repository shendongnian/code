    private void SharePointSanitize(string _folder)
    {
        // Process files in the directory
        string [] files = Directory.GetFiles(_folder);
        foreach(string fileName in files)
        {
            File.Move(fileName, SharePointRename(fileName));
        }
        string[] folders = Directory.GetDirectories(_folder);
        foreach(string folderName in folders)
        {
            SharePointSanitize(folderName);
        }
    }
    
    private string SharePointRename(string _name)
    {
        string newName = _name;
        newName = newName.Replace('~', '');
        newName = newName.Replace('#', '');
        newName = newName.Replace('%', '');
        newName = newName.Replace('&', '');
        newName = newName.Replace('*', '');
        newName = newName.Replace('{', '');
        newName = newName.Replace('}', '');
        // .. and so on
        return newName;
    }
