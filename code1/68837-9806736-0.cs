    /// <summary>
    /// Finds the next unused unique (numbered) filename.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="inUse">Function that will determine if the name is already in use</param>
    /// <returns>The original filename if it wasn't already used, or the filename with " (n)"
    /// added to the name if the original filename is already in use.</returns>
    private static string NextUniqueFilename(string fileName, Func<string, bool> inUse)
    {
        if (!inUse(fileName))
        {
            // this filename has not been seen before, return it unmodified
            return fileName;
        }
        // this filename is already in use, add " (n)" to the end
        var name = Path.GetFileNameWithoutExtension(fileName);
        var extension = Path.GetExtension(fileName);
        if (name == null)
        {
            throw new Exception("File name without extension returned null.");
        }
        const int max = 9999;
        for (var i = 1; i < max; i++)
        {
            var nextUniqueFilename = string.Format("{0} ({1}){2}", name, i, extension);
            if (!inUse(nextUniqueFilename))
            {
                return nextUniqueFilename;
            }
        }
        throw new Exception(string.Format("Too many files by this name. Limit: {0}", max));
    }
