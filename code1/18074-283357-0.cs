        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo("CtrlCClient.exe");
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            Process proc = Process.Start(psi);
            Console.WriteLine("{0} is active: {1}", proc.Id, !proc.HasExited);
            proc.StandardInput.WriteLine("\x3");
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            Console.WriteLine("{0} is active: {1}", proc.Id, !proc.HasExited);
            Console.ReadLine();
        }
