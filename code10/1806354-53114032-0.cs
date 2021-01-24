      public sealed class ExecutionSqlCmdResult {
        public  ExecutionSqlCmdResult(string stdOut, string stdErr, int exitCode)
          : base() {
    
          Out = string.IsNullOrWhiteSpace(stdOut) ? "" : stdOut;
          Error = string.IsNullOrWhiteSpace(stdErr) ? "" : stdErr;
          ExitCode = exitCode;
        }
    
        public string Out {
          get;
        }
    
        public string Error {
          get;
        }
    
        public int ExitCode {
          get;
        }
      }
