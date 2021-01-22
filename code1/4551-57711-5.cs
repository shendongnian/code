    namespace TimedReadLine
    {
       public static class Console
       {
          private delegate string ReadLineInvoker();
          public static string ReadLine(int timeout)
          {
             return ReadLine(timeout, null);
          }
          public static string ReadLine(int timeout, string @default)
          {
             using (var process = new System.Diagnostics.Process
             {
                StartInfo =
                {
                   FileName = "ReadLine.exe",
                   RedirectStandardOutput = true,
                   UseShellExecute = false
                }
             })
             {
                process.Start();
                var rli = new ReadLineInvoker(process.StandardOutput.ReadLine);
                var iar = rli.BeginInvoke(null, null);
                if (!iar.AsyncWaitHandle.WaitOne(new System.TimeSpan(0, 0, timeout)))
                {
                   process.Kill();
                   return @default;
                }
                return rli.EndInvoke(iar);
             }
          }
       }
    }
