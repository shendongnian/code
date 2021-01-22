    /// <summary>
    /// Gets a value that indicates whether <paramref name="path"/>
    /// is a valid path.
    /// </summary>
    /// <returns>Returns <c>true</c> if <paramref name="path"/> is a
    /// valid path; <c>false</c> otherwise. Also returns <c>false</c> if
    /// the caller does not have the required permissions to access
    /// <paramref name="path"/>.
    /// </returns>
    /// <seealso cref="Path.GetFullPath"/>
    /// <seealso cref="TryGetFullPath"/>
    public static bool IsValidPath(string path)
    {
        string result;
        return TryGetFullPath(path, out result);
    }
    /// <summary>
    /// Returns the absolute path for the specified path string. A return
    /// value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="path">The file or directory for which to obtain absolute
    /// path information.
    /// </param>
    /// <param name="result">When this method returns, contains the absolute
    /// path representation of <paramref name="path"/>, if the conversion
    /// succeeded, or <see cref="String.Empty"/> if the conversion failed.
    /// The conversion fails if <paramref name="path"/> is null or
    /// <see cref="String.Empty"/>, or is not of the correct format. This
    /// parameter is passed uninitialized; any value originally supplied
    /// in <paramref name="result"/> will be overwritten.
    /// </param>
    /// <returns><c>true</c> if <paramref name="path"/> was converted
    /// to an absolute path successfully; otherwise, false.
    /// </returns>
    /// <seealso cref="Path.GetFullPath"/>
    /// <seealso cref="IsValidPath"/>
    public static bool TryGetFullPath(string path, out string result)
    {
        result = String.Empty;
        if (String.IsNullOrWhiteSpace(path)) { return false; }
        bool status = false;
        try
        {
            result = Path.GetFullPath(path);
            status = true;
        }
        catch (ArgumentException) { }
        catch (SecurityException) { }
        catch (NotSupportedException) { }
        catch (PathTooLongException) { }
        return status;
    }
