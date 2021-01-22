        /// <summary>
        /// Creates new process to run and executable file, and return the output
        /// </summary>
        /// <param name="program">The name of the executable to run</param>
        /// <param name="arguments">Any parameters that are required by the executable</param>
        /// <param name="silent">Determines whether or not we output execution details</param>
        /// <param name="workingDirectory">The directory to run the application process from</param>
        /// <param name="standardErr">The standard error from the executable. String.Empty if none returned.</param>
        /// <param name="standardOut">The standard output from the executable. String.Empty if none returned, or silent = true</param>
        /// <returns>The application's exit code.</returns>
        public static int Execute(string program, string arguments, bool silent, string workingDirectory, out string standardOut, out string standardErr)
        {
            standardErr = String.Empty;
            standardOut = String.Empty;
            //sometimes it is not advisable to output the arguments e.g. passwords etc
            if (!silent)
            {
                Console.WriteLine(program + " " + arguments);
            }
            Process proc = Process.GetCurrentProcess();
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                //execute from the specific working directory if specified
                proc.StartInfo.WorkingDirectory = workingDirectory;
            }
            proc.EnableRaisingEvents = true;
            proc.StartInfo.FileName = program;
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            proc.WaitForExit();
            //only display the console output if not operating silently
            if (!silent)
            {
                if (proc.StandardOutput != null)
                {
                    standardOut = proc.StandardOutput.ReadToEnd();
                    Console.WriteLine(standardOut);
                }     
            }
            if (proc.StandardError != null)
            {
                standardErr = proc.StandardError.ReadToEnd();
                Console.WriteLine(standardErr);
            }
            proc.StandardOutput.Close();
            proc.StandardError.Close();
            return proc.ExitCode;
        }
