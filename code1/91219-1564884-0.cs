    using System;
    using System.Diagnostics;
    namespace Launcher
    {
      public static class Program
      {
        public static void Main(string[] args)
        {
          ProcessStartInfo startInfo = new ProcessStartInfo();
          startInfo.FileName = args[0];
          startInfo.WindowStyle = ProcessWindowStyle.Normal;
          Process.Start(startInfo);
        }
      }
    }
