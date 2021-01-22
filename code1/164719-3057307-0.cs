    public static void RestartMe(string commandLine)
    {
      var myId = Process.GetCurrentProcess().Id;
      var myPath = Assembly.GetEntryAssembly().CodeBase.Replace("file:///", "");
      var systemPath = typeof(object).Assembly.CodeBase.Replace("file:///", "");
      var tempPath = Path.GetTempFileName();
      File.WriteAllText(tempPath + ".cs", @"
        using System;
        using System.Diagnostics;
        public class App
        {
          public static void Main(string[] args)
          {
            try { Process.GetProcessById(" + myId + @").WaitForExit(); } catch {}
            Process.Start(""" + myPath + @""", Environment.CommandLine);
          }
        }");
      var compiler = new ProcessStartInfo
      {
        FileName = Path.Combine(Path.GetDirectoryName(systemPath), "csc.exe"),
        Arguments = tempPath + ".cs",
        WorkingDirectory = Path.GetDirectoryName(tempPath),
        WindowStyle = ProcessWindowStyle.Hidden,
      };
      var restarter = new ProcessStartInfo
      {
        FileName = tempPath + ".exe",
        Arguments = commandLine,
        WindowStyle = ProcessWindowStyle.Hidden,
      };
      Process.Start(compiler).WaitForExit();
      Process.Start(restarter); // No WaitForExit: restarter WaitForExits us instead
      File.Delete(tempPath);
      File.Delete(tempPath + ".cs");
      Environment.Exit(0);
    }
