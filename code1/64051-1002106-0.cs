    protected bool IsDesignTime
    {
        get
        {
            // Determine if this instance is running against .NET Framework by using the MSCoreLib PublicKeyToken
            System.Reflection.Assembly mscorlibAssembly = typeof(int).Assembly;
            if ((mscorlibAssembly != null))
            {
                if (mscorlibAssembly.FullName.ToUpper().EndsWith("B77A5C561934E089"))
                {
                    return true;
                }
            }
            return false;
        }
    }
