    public static bool DoConsoleSetep(bool ClearLineIfParentConsole)
    {
      if (GetConsoleWindow() != System.IntPtr.Zero)
      {
        return true;
      }
      if (AttachConsole(ATTACH_PARENT_PROCESS))
      {
        System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Console.OpenStandardOutput());
        sw.AutoFlush = true;
        System.Console.SetOut(sw);
        System.Console.SetError(sw);
        ConsoleSetupWasParentConsole = true;
        if (ClearLineIfParentConsole)
        {
          // Clear command prompt since windows thinks we are a windowing app
          System.Console.CursorLeft = 0;
          char[] bl = System.Linq.Enumerable.ToArray<char>(System.Linq.Enumerable.Repeat<char>(' ', System.Console.WindowWidth - 1));
          System.Console.Write(bl);
          System.Console.CursorLeft = 0;
        }
        return true;
      }
      int Error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
      if (Error == ERROR_ACCESS_DENIED)
      {
        if (log.IsDebugEnabled) log.Debug("AttachConsole(ATTACH_PARENT_PROCESS) returned ERROR_ACCESS_DENIED");
        return true;
      }
      if (Error == ERROR_INVALID_HANDLE)
      {
        if (AllocConsole())
        {
          System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Console.OpenStandardOutput());
          sw.AutoFlush = true;
          System.Console.SetOut(sw);
          System.Console.SetError(sw);
          return true;
        }
      }
      return false;
    }
