    public static string runCommand(string workingDirectory, string command)
        { 
            // Create the ProcessInfo object
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = workingDirectory;
            // Start the process
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
            // Attach the output for reading
            System.IO.StreamReader sOut = proc.StandardOutput;
            // Attach the in for writing
            System.IO.StreamWriter sIn = proc.StandardInput;
            sIn.WriteLine(command);
            // strm.Close();
            // Exit CMD.EXE
            string stEchoFmt = "# {0} run successfully. Exiting";
           // sIn.WriteLine(String.Format(stEchoFmt, targetBat));
            sIn.WriteLine("EXIT");
            // Close the process
            proc.Close();
            // Read the sOut to a string.
            string results = sOut.ReadToEnd().Trim();
            // Close the io Streams;
            sIn.Close();
            sOut.Close();
            // Write out the results.
            string fmtStdOut = "<font face=courier size=0>{0}</font>";
            return String.Format(fmtStdOut, results.Replace(System.Environment.NewLine, "<br>"));
        }
