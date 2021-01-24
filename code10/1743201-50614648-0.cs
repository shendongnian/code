    static void LaunchProgram()
        {
            // Path to program
            const string ex2 = "C:\\Dir";
    
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
    
            //File name of program to launch
            startInfo.FileName = "program.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                 // Log error.
            }
        }
