    ProcessStartInfo info = new ProcessStartInfo(TheProgram);
    info.CreateNoWindow = true;
    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    info.RedirectStandardOutput = true;
    info.UseShellExecute = false;
    Process p = Process.Start(info);
    string record = p.StandardOutput.ReadLine();
    while (record != null)
    {
        Console.WriteLine(record);
        record = p.StandardOutput.ReadLine();
    }
    p.WaitForExit();
