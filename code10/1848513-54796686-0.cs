    var proc = new System.Diagnostics.ProcessStartInfo();
    proc.UseShellExecute = true;
    proc.Verb = "runas";
    proc.FileName = @"powershell.exe";
    proc.Arguments = "-NoProfile -Command " + command;
    proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    var p = System.Diagnostics.Process.Start(proc);
    p.WaitForExit();
