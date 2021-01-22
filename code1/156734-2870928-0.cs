            StreamReader stdOut;
            Process proc1 = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("CMD.EXE", "/C dir %appdata%");
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            proc1.StartInfo = psi;
            proc1.Start();
            stdOut = proc1.StandardOutput;
            System.Diagnostics.Debug.Write(stdOut.ReadToEnd());
