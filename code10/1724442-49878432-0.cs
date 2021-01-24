    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    process.StartInfo.FileName = "C://PATH//ABC.exe";
    process.StartInfo.Arguments = "ARGUMENT";
    
    process.Start();
    process.WaitForExit();
