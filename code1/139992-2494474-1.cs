    Process process = new Process();
    // Fill process.StartInfo
    process.Start();
    do
    {
        System.Threading.Sleep(100);
        process.Refresh();
    }
    while(process.MainWindowHandle == IntPtr.Zero && !process.HasExited);
    if(!process.HasExited)
    {
        IntPtr hwnd = process.MainWindowHandle;
        // Do whatever you need to do with hwnd
    }
