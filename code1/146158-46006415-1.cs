    public static string GetCommandLineOfProcess(Process proc)
    {
        // max size of a command line is USHORT/sizeof(WCHAR), so we are going
        // just allocate max USHORT for sanity's sake.
        var sb = new StringBuilder(0xFFFF);
        switch (IntPtr.Size)
        {
            case 4: GetProcCmdLine32((uint)proc.Id, sb, (uint)sb.Capacity); break;
            case 8: GetProcCmdLine64((uint)proc.Id, sb, (uint)sb.Capacity); break;
        }
        return sb.ToString();
    }
