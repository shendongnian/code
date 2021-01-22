    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var startInfo = new ProcessStartInfo("nslookup");
                startInfo.Arguments = "-type=TXT google.com";
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
                using (var cmd = Process.Start(startInfo))
                {
                  // This is where you grab the output from nslookup.
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                }
                Console.Read();
            }
        }
    }
