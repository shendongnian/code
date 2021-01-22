    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo("ping")
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = "google.com"
            };
            Process proc = Process.Start(psi);
            proc.EnableRaisingEvents = true;
            proc.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            proc.BeginOutputReadLine();
            proc.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
            proc.BeginErrorReadLine();
            proc.WaitForExit();
            Console.WriteLine("Done");
        }
    }
