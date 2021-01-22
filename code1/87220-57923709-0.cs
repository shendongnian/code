public static class PathHelper
{
    /// <summary>
    /// Determines whether the given path refers to an existing file or directory on disk.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <param name="isDirectory">When this method returns, contains true if the path was found to be an existing directory, false in all other scenarios.</param>
    /// <returns>true if the path exists; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="path"/> is null.</exception>
    /// <exception cref="ArgumentException">If <paramref name="path"/> equals <see cref="string.Empty"/></exception>
    public static bool PathExists(string path, out bool isDirectory)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        if (path == string.Empty) throw new ArgumentException("Value cannot be empty.", nameof(path));
        isDirectory = Directory.Exists(path);
        return isDirectory || File.Exists(path);
    }
}
This helper method is written to be verbose and concise enough to understand the intent the first time you read it.
/// <summary>
/// Example usage of <see cref="PathExists(string, out bool)"/>
/// </summary>
public static void Usage()
{
    const string path = @"C:\dev";
    if (!PathHelper.PathExists(path, out var isDirectory))
        return;
    if (isDirectory)
    {
        // Do something with your directory
    }
    else
    {
        // Do something with your file
    }
}
