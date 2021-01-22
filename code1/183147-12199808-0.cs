    public static bool ExecuteWritesToDiskSvnCommand(string command, string arguments, string destinationFile, out string errors)
            {
                bool retval = false;
                string errorLines = string.Empty;
                Process svnCommand = null;
                ProcessStartInfo psi = new ProcessStartInfo(command);
        
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
        
                try
                {
                    Process.Start(psi);
                    psi.Arguments = arguments;
                    svnCommand = Process.Start(psi);
        
                    StreamReader myOutput = svnCommand.StandardOutput;
                    StreamReader myErrors = svnCommand.StandardError;
        
                    File.AppendAllText(destinationFile, myOutput.ReadToEnd());
                    svnCommand.WaitForExit();
                    File.AppendAllText(destinationFile, myOutput.ReadToEnd());
        
                    if (svnCommand.HasExited)
                    {
                        errorLines = myErrors.ReadToEnd();
                    }
        
                    // Check for errors
                    if (errorLines.Trim().Length == 0)
                    {
                        retval = true;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    errorLines += Environment.NewLine + msg;
                }
                finally
                {
                    if (svnCommand != null)
                    {
                        svnCommand.Close();
                    }
                }
        
                errors = errorLines;
        
                return retval;
            }
