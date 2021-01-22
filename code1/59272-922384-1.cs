    using System;
    using System.Diagnostics;
    class Program
    {
      static void Main(string[] args)
      {
        string name;
        if (args.Length > 0 && args[0] == "slave")
        {
          name = "slave";
        }
        else
        {
          name = "master";
          var info = new ProcessStartInfo();
          info.FileName = "BidirConsole.exe";
          info.Arguments = "slave";
          info.RedirectStandardInput = true;
          info.RedirectStandardOutput = true;
          info.UseShellExecute = false;
          var other = Process.Start(info);
          Console.SetIn(other.StandardOutput);
          Console.SetOut(other.StandardInput);
        }
        Console.WriteLine(name + " started.");
        while (true)
        {
          var incoming = Console.ReadLine();
          var outgoing = name + " got : " + incoming;
          Console.WriteLine(outgoing);
          System.Threading.Thread.Sleep(100);
        }
      }
    }
