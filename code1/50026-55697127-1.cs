    [DebuggerNonUserCode]
    private static IEnumerable<Process> GetProcesses() =>
      Process.GetProcesses().Where(p => {
        var hasException = false;
        try {
          var x = p.Handle;
        } catch {
          hasException = true;
        }
        return !hasException;
      }).ToArray();
