    public static string Combine(string path1, string path2)
    {
        if ((path1 == null) || (path2 == null))
        {
            throw new ArgumentNullException((path1 == null) ? "path1" : "path2");
        }
        CheckInvalidPathChars(path1);
        CheckInvalidPathChars(path2);
        if (path2.Length == 0)
        {
            return path1;
        }
        if (path1.Length == 0)
        {
            return path2;
        }
        if (IsPathRooted(path2))
        {
            return path2;
        }
        char ch = path1[path1.Length - 1];
        if (((ch != DirectorySeparatorChar) && (ch != AltDirectorySeparatorChar)) && (ch != VolumeSeparatorChar))
        {
            return (path1 + DirectorySeparatorChar + path2);
        }
        return (path1 + path2);
    }
    
     
    public static bool IsPathRooted(string path)
    {
        if (path != null)
        {
            CheckInvalidPathChars(path);
            int length = path.Length;
            if (((length >= 1) && ((path[0] == DirectorySeparatorChar) || (path[0] == AltDirectorySeparatorChar))) || ((length >= 2) && (path[1] == VolumeSeparatorChar)))
            {
                return true;
            }
        }
        return false;
    }
    
     
    
     
    
     
