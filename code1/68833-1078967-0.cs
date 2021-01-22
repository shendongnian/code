    /// <summary>
    /// Created a Unique filename for the given filename
    /// </summary>
    /// <param name="filename">A full filename, e.g., c:\temp\myfile.tmp</param>
    /// <returns>A filename like c:\temp\myfile633822247336197902.tmp</returns>
    public string GetUniqueFilename(string filename)
    {
        string basename = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename));
        string uniquefilename = string.Format("{0}{1}{2}", basename, DateTime.Now.Ticks, Path.GetExtension(filename));
        // Thread.Sleep(1); // To really prevent collisions, but usually not needed
        return uniquefilename;
    }
