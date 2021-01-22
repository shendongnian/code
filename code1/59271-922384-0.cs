    using System;
    using System.Diagnostics;
    class Program
    {
      static void Main(string[] args)
      {
        var info = new ProcessStartInfo();
        info.FileName = "whatever.exe";
        info.RedirectStandardInput = true;
        info.RedirectStandardOutput = true;
        var other = Process.Start(info);
        Console.SetIn(other.StandardOutput);
        Console.SetOut(other.StandardInput);
      }
    }
