    string sCommand = "netstat";
    string sArgs = "";
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo (sCommand, sArgs);
    
    psi.UseShellExecute = false;
    psi.RedirectStandartOutput = true;
    
    System.Diagnostics.Process proc = null;
    proc = System.Diagnostics.Process.Start(psi);
    proc.WaitForExit();
    
    // Read the first 4 lines. They don't contain any information we need to get
    for (int i = 0; i < 4; i++)
        proc.StandardOutput.ReadLine();
    
    while (true)
    {
        string strLine = proc.StandardOutput.ReadLine();
        if (strLine == null)
            break;
    
        // Analyze the line 
        // Line is in following structure:
        // Protocol (TCP/UDP)   Local Address(host:port) Foreign Address(host:port) State(ESTABLISHED, ...)
    }
