    #region IsDirectory
    /// <summary>
    /// Verifies that a path is a valid directory.
    /// </summary>
    /// <param name="path">The path to verify.</param>
    /// <returns><see langword="true"/> if the path is a valid directory; 
    /// otherwise, <see langword="false"/>.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <para><paramref name="path"/> is <see langword="null"/>.</para>
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// <para><paramref name="path"/> is <see cref="F:System.String.Empty">String.Empty</see>.</para>
    /// </exception>
    public static bool IsDirectory(string path)
    {
        return PathIsDirectory(path);
    }
