    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
    pProcess.StartInfo.FileName = @"C:\Users\Vitor\ConsoleApplication1.exe";
    pProcess.StartInfo.Arguments = "olaa"; //argument
    pProcess.StartInfo.UseShellExecute = false;
    pProcess.StartInfo.RedirectStandardOutput = true;
    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
    pProcess.Start();
    string output = pProcess.StandardOutput.ReadToEnd(); //The output result
    pProcess.WaitForExit();
