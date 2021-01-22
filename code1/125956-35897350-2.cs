    public void RemoveDirectory(string directoryPath)
    {
        var path = @"\\?\UNC\" + directoryPath.Trim(@" \/".ToCharArray());
        SearchAndDelete(path);
    }
    
