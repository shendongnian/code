    private static void MakeDumpFile()
        {            
            int pid = Process.GetCurrentProcess().Id;
            Console.WriteLine("Creating dump for pid " + pid);
            
            //path to adplus executable; ensure you have Debugging tools installed;
            string program = @"C:\Program Files (x86)\Debugging Tools for Windows (x86)\adplus.exe";
            
            //args for adplus; ensure the crashdump folder exists!
            string args = string.Format(@"-hang -p {0} -o c:\crashdump", pid);
            var startInfo = new ProcessStartInfo(program, args);
            startInfo.UseShellExecute = false;
            startInfo.ErrorDialog = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            var process = Process.Start(startInfo);
            Console.WriteLine("The following is output from adplus");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine("Finished creating dump.");
        }
