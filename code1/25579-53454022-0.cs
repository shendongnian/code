    /// <summary>
    /// get the directory path segments.
    /// </summary>
    /// <param name="directoryPath">the directory path.</param>
    /// <returns>a IEnumerable<string> containing the get directory path segments.</returns>
    public IEnumerable<string> GetDirectoryPathSegments(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
        { throw new Exception($"Invalid Directory: {directoryPath ?? "null"}"); }
    
        var currentNode = new System.IO.DirectoryInfo(directoryPath);
    
        var targetRootNode = currentNode.Root;
        if (targetRootNode == null) return new string[] { currentNode.Name };
        var directorySegments = new List<string>();
        while (string.Compare(targetRootNode.FullName, currentNode.FullName, StringComparison.InvariantCultureIgnoreCase) != 0)
        {
            directorySegments.Insert(0, currentNode.Name);
            currentNode = currentNode.Parent;
        }
        directorySegments.Insert(0, currentNode.Name);
        return directorySegments;
    }
