    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo = 
        new System.Diagnostics.ProcessStartInfo("C:\...\...\myfile.html");
    process.Start();
    process.WaitForExit(); // this line is the key difference
