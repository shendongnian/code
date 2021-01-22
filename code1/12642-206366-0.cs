    //Create process
    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
    
    //strCommand is path and file name of command to run
    pProcess.StartInfo.FileName = strCommand;
    //strCommandParameters are parameters to pass to program
    pProcess.StartInfo.Arguments = strCommandParameters;
    
    pProcess.StartInfo.UseShellExecute = false;
    //Set output of program to be written to process output stream
    pProcess.StartInfo.RedirectStandardOutput = true;	
    
    //Optional
    pProcess.StartInfo.WorkingDirectory = strWorkingDirectory;
    //Start the process
    pProcess.Start();
    
    //Get program output
    string strOutput = pProcess.StandardOutput.ReadToEnd();
    
    //Wait for process to finish
    pProcess.WaitForExit();
