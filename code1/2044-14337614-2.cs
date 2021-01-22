    [STAThread]
    public static void Main()
    {
        String assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        using (Mutex mutex = new Mutex(false, assemblyName))
        {
            if (!mutex.WaitOne(0, false))
            {
                Boolean shownProcess = false;
                Process currentProcess = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                {
                    if (!process.Id.Equals(currentProcess.Id) && process.MainModule.FileName.Equals(currentProcess.MainModule.FileName) && !process.MainWindowHandle.Equals(IntPtr.Zero))
                    {
                        IntPtr windowHandle = process.MainWindowHandle;
                        if (NativeMethods.IsIconic(windowHandle))
                            NativeMethods.ShowWindow(windowHandle, ShowWindowCommand.Restore);
                        NativeMethods.SetForegroundWindow(windowHandle);
                        shownProcess = true;
                    }
                }
                if (!shownProcess)
                    MessageBox.Show(String.Format(CultureInfo.CurrentCulture, "An instance of {0} is already running!", assemblyName), assemblyName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form());
            }
        }
    }
