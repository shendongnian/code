    protected static bool IsRunAsService()
    {
        string CurDir = Directory.GetCurrentDirectory();
        if (CurDir.Equals(Environment.SystemDirectory, StringComparison.CurrentCultureIgnoreCase))
        { 
             return true; 
        }
        return (false);
    }
