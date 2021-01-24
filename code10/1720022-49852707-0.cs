    [DllImport("AltixDll.dll", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
    public extern static int AltixDllVersion([MarshalAs(UnmanagedType.LPStr)] StringBuilder DllVersion);
    StringBuilder str = new StringBuilder();
    DllSolderMask.AltixDllVersion(str);
    lblDll.Text = str.ToString();
