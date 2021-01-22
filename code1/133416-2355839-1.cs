        public static String ShellExec( String pExeFN, String pParams, out int exit_code)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(pExeFN, pParams);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false; // the process is created directly from the executable file
            psi.CreateNoWindow = true;
            using (System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi))
            {
                string tool_output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                exit_code = p.ExitCode;
                return tool_output;
            }
        }
