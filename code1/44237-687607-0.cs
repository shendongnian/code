            ProcessStartInfo processStartInfo = new ProcessStartInfo (programExePath, commandLineArgs);
            consoleLogger.WriteLine (log, Level.Debug, "Running program {0} ('{1}')", programExePath, commandLineArgs);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.ErrorDialog = false;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            using (Process process = new Process ())
            {
                process.StartInfo = processStartInfo;
                process.ErrorDataReceived += new DataReceivedEventHandler (process_ErrorDataReceived);
                process.OutputDataReceived += new DataReceivedEventHandler (process_OutputDataReceived);
                process.Start ();
                process.BeginOutputReadLine ();
                process.BeginErrorReadLine ();
                if (false == process.WaitForExit ((int)TimeSpan.FromHours(1).TotalMilliseconds))
                    throw new ArgumentException("The program '{0}' did not finish in time, aborting.", programExePath);
                if (process.ExitCode != 0)
                    throw new ArgumentException ("failed.");
            }
