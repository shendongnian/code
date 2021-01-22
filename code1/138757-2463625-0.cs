    Process[] processes = Process.GetProcessesByName(fileType);
    foreach (Process p in processes)
    {
        IntPtr pFoundWindow = p.MainWindowHandle;
        if (p.MainWindowTitle.Contains(documentName))
        {
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(p_Exited);
            p.CloseMainWindow();
        }                       
    }
