    /// <summary>
    /// Determines whether the specified application executable is installed.
    /// </summary>
    /// <param name="name">The command line name.</param>
    /// <returns><c>true</c> if the specified name is installed; otherwise, <c>false</c>.</returns>
    public static bool IsInstalled(string name)
    {
        using (var key = Registry.ClassesRoot.OpenSubKey($"{name}\\shell\\open\\command"))
            return key != null;
    }
