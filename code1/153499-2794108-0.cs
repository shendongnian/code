    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          for (int ix = 0; ix < 100; ++ix) {
            var psi = new ProcessStartInfo(@"c:\bin\handle.exe", @"-p consoleapplication1");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            var prc = Process.Start(psi);
            var txt = prc.StandardOutput.ReadToEnd();
            Console.WriteLine(txt);
            System.Threading.Thread.Sleep(1000);
          }
          Console.ReadLine();
        }
      }
    }
