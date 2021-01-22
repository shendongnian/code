    private int CallShell(string exeCommand, string Parameters)
            {
                //http://ss64.com/nt/cmd.html
                /*
                This function will actually take the shell string and envoke the appropriate process
                 passing it the arguments to do the work
                */
     
                // Initialize the process and its StartInfo properties.
                System.Diagnostics.Process ProcessEXE = new System.Diagnostics.Process();
     
                logger.DebugFormat("About to Start Process - {0} {1}",exeCommand, Parameters);
                try
                {
     
                    ProcessEXE.StartInfo.FileName = exeCommand;
     
     
                    // Set UseShellExecute to false for redirection.
                    //  false if the process should be created directly from the executable file
                    ProcessEXE.StartInfo.UseShellExecute = false;
                    ProcessEXE.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory;
     
                    //EnableRaisingEvents property indicates whether the component should be notified when the operating system has shut down a process
     
                    ProcessEXE.StartInfo.Arguments = Parameters;
     
                    ProcessEXE.StartInfo.RedirectStandardOutput = true;
                    ProcessEXE.StartInfo.RedirectStandardError = true;
                    ProcessEXE.EnableRaisingEvents = true;
                    ProcessEXE.StartInfo.CreateNoWindow = true;
     
                    ProcessEXE.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ProcessEXE_OutputDataReceived);
                    ProcessEXE.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ProcessEXE_OutputDataReceived);
     
                    logger.DebugFormat("Process Started.");
                    ProcessEXE.Start();
     
     
                    // Start the asynchronous read of the sort output stream.
                    ProcessEXE.BeginErrorReadLine();
                    ProcessEXE.BeginOutputReadLine();
     
                    //The WaitForExit overload is used to make the current thread wait until the associated process terminates
                    logger.DebugFormat("Process Waiting for exit.");
                    ProcessEXE.WaitForExit();
     
                    if (ProcessEXE.ExitCode == 0)
                    {
                        logger.Debug(string.Format("Shell Process exited with exit code {0}", ProcessEXE.ExitCode));
                    }
                    else
                    {
                    // throw error here if required - check the return error code
                        logger.Warn(string.Format("Shell Process exited with exit code {0}", ProcessEXE.ExitCode));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Method:{0}", ex.TargetSite), ex);
                }
     
                return ProcessEXE.ExitCode;
            }
    
    
    void ProcessEXE_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                try
                {
                    StringBuilder sb = new StringBuilder(string.Empty);
                    if (e == null) return;
     
                    if (e.Data == null)
                    {
                        //No processing
                    }
                    else
                    {
                       // your logic to detect error msg out from output - if at all required
                    }
     
                    if (sb.ToString().ToUpper().IndexOf("ERROR") > 0)
                    {
                        string smessage = "Error text found in  output.";
    
    				// do your error response action here .
    
                    }
                }
                catch (Exception exp)
                {
                    logger.ErrorFormat("Error in ProcessEXE_OutputDataReceived Message:{0}", exp.Message);
                    logger.ErrorFormat("Error in ProcessEXE_OutputDataReceived Data Received:{0}", e.Data);
    
    			// either throw error msg or kill the process 
                }
                finally
                {
                    // Not throwing the exception
                }
            }
