    _restartInProgress = true;
    string dropFilename = Path.Combine(Application.StartupPath, "restart.dat");
    StreamWriter sw = new StreamWriter(new FileStream(dropFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
    sw.WriteLine(Application.ExecutablePath);
    sw.WriteLine(Application.StartupPath);
    sw.Flush();
    Process.Start(new ProcessStartInfo
    {
        FileName = Path.Combine(Application.StartupPath, "VideoPhill.Restarter.exe"),
        WorkingDirectory = Application.StartupPath,
        Arguments = string.Format("\"{0}\"", dropFilename)
    });
    Close();
