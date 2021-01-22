      [DllImport("kernel32.dll")]
      public static extern bool QueryFullProcessImageName(IntPtr hprocess, int dwFlags, StringBuilder lpExeName, out int size);
      private bool CheckRunningProcess(string processName, string path) {
      Process[] processes = Process.GetProcessesByName(processName);
      foreach(Process p in processes) {
        var name = GetMainModuleFileName(p);
        if (name == null)
          continue;
        if (string.Equals(name, path, StringComparison.InvariantCultureIgnoreCase)) {
          return true;
        }
      }
      return false;
    }
    // Get x64 process module name from x86 process
    private static string GetMainModuleFileName(Process process, int buffer = 1024) {
      var fileNameBuilder = new StringBuilder(buffer);
      int bufferLength = fileNameBuilder.Capacity + 1;
      return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, out bufferLength) ?
          fileNameBuilder.ToString() :
          null;
    }
