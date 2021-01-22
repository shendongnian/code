        using (System.Diagnostics.Process process = new System.Diagnostics.Process())
        {
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"c:\windows\system32\cmd.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.ErrorDialog = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();
            //// do some other things while you wait...
            System.Threading.Thread.Sleep(10000); // simulate doing other things...
            process.StandardInput.WriteLine("exit"); // tell console to exit
            if (!process.HasExited)
            {
                process.WaitForExit(120000); // give 2 minutes for process to finish
                if (!process.HasExited)
                {
                    process.Kill(); // took too long, kill it off
                }
            }
        }
