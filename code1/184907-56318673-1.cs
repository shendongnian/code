    /// <summary>
    /// Determines whether a file exists within the specified folder
    /// </summary>
    /// <param name="bucket">The name of the bucket to search</param>
    /// <param name="folder">The name of the folder to search</param>
    /// <param name="filePrefix">Match files that begin with this prefix</param>
    /// <returns>True if the file exists</returns>
    public async Task<bool> FileExists(string bucket, string folder, string filePrefix)
    {
        return await FileExists(bucket, $"{folder}/{filePrefix}");
    }
