    // Create a process
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    // Set the StartInfo of process
    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    process.StartInfo.FileName = "C://PATH//ABC.exe";
    process.StartInfo.Arguments = "ARGUMENT";
    
    // Start the process
    process.Start();
    process.WaitForExit();
