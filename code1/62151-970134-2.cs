    public static string GetKnownFolderPath(Guid guid)
    {
      try
      {
        IntPtr pPath;
        int result = SHGetKnownFolderPath(guid, 0, IntPtr.Zero, out pPath);
        if (result == 0)
        {
            string s = Marshal.PtrToStringUni(pPath);
            Marshal.FreeCoTaskMem(pPath);
            return s;
        }
        else
            throw new System.ComponentModel.Win32Exception(result);
      }
      catch(EntryPointNotFoundException ex)
      {
        DoAlternativeSolution();
      }
    }
