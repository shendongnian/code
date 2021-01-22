        static String ShellExec( String pExeFN, String parms, out int exit_code)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(pExeFN, parms);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false; // the process is created directly from the executable file
            psi.CreateNoWindow = true;
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
            string tool_output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            exit_code = p.ExitCode;
            return tool_output;
        }
