    interface IFileFilter
    {
        string GetFilterName();
        string GetFilterReadableName();
        FileInfo[] GetFilteredFiles(string path, string filter);
    }
