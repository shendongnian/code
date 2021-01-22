    public static void rmdir(string target, bool recursive)
    {
        string tfilename = Path.GetDirectoryName(target) +
            (target.Contains(Path.DirectorySeparatorChar.ToString()) ? Path.DirectorySeparatorChar.ToString() : string.Empty) +
            Path.GetRandomFileName();
        Directory.Move(target, tfilename);
        Directory.Delete(tfilename, recursive);
    }
