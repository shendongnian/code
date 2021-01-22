    System.Diagnostics.ProcessStartInfo psi =
        new System.Diagnostics.ProcessStartInfo(@"ipconfig");
    psi.RedirectStandardOutput = true;
    psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    psi.UseShellExecute = false;
                
    System.Diagnostics.Process myProcess;
    myProcess = System.Diagnostics.Process.Start(psi);
    System.IO.StreamReader myOutput = myProcess.StandardOutput; // Capture output
    myProcess.WaitForExit(2000);
    if (myProcess.HasExited)
    {
        string output = myOutput.ReadToEnd();
        Console.WriteLine(output);
    }
