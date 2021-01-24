      public static ExecutionSqlCmdResult ExecuteSqlCmd(string command) {
        ProcessStartInfo sqlCmdInfo = new ProcessStartInfo() {
          UseShellExecute = false,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden,
          RedirectStandardError = true,
          RedirectStandardOutput = true,
          Arguments = command,
          FileName = "sqlcmd",
          StandardErrorEncoding = Encoding.UTF8,
          StandardOutputEncoding = Encoding.UTF8,
        };
    
        using (Process sqlCmdProcess = new Process()) {
          sqlCmdProcess.StartInfo = sqlCmdInfo;
          sqlCmdProcess.Start();
    
          StringBuilder sbOut = new StringBuilder();
          StringBuilder sbErr = new StringBuilder();
    
          sqlCmdProcess.OutputDataReceived += (sender, e) => {
            if (e.Data != null)
              sbOut.Append(e.Data);
          };
    
          sqlCmdProcess.ErrorDataReceived += (sender, e) => {
            if (e.Data != null)
              sbErr.Append(e.Data);
          };
    
          sqlCmdProcess.BeginErrorReadLine();
          sqlCmdProcess.BeginOutputReadLine();
    
          sqlCmdProcess.WaitForExit();
    
          return new ExecutionSqlCmdResult(sbOut.ToString(), sbErr.ToString(), sqlCmdProcess.ExitCode);
        }
      }
