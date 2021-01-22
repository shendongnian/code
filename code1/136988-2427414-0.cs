    public static bool InVisualStudio() {
      return StringComparer.OrdinalIgnoreCase.Equals(
        "devenv", 
        Process.CurrentProcess.ProcessName);
    }
