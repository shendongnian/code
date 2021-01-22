    public static void CopyFile(string source, string dest)
    {
        source = fixPathForLong(source);
        dest = fixPathForLong(dest);
    
        if (!CopyFile(source, dest, false))
        {
            throw new Win32Exception();
        }
    }
