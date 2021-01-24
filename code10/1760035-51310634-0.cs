    // Tests if the given path contains a root. A path is considered rooted
    // if it starts with a backslash ("\") or a drive letter and a colon (":").
    //
    [Pure]
    public static bool IsPathRooted(String path) {
        if (path != null) {
            CheckInvalidPathChars(path);
                
            int length = path.Length;
            if ((length >= 1 && (path[0] == DirectorySeparatorChar || path[0] == AltDirectorySeparatorChar)) || (length >= 2 && path[1] == VolumeSeparatorChar))
                 return true;
        }
        return false;
    }
