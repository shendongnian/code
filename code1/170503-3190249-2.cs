    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    static void Main()
    {
        if (!EnsureSingleInstance())
        {
            return;
        }
        //...
    }
    static bool EnsureSingleInstance()
    {
        Process currentProcess = Process.GetCurrentProcess();
        string applicationTitle = ((AssemblyTitleAttribute)Attribute
            .GetCustomAttribute(Assembly.GetExecutingAssembly(),
            typeof(AssemblyTitleAttribute), false)).Title;
        var runningProcess = (from process in Process.GetProcesses()
                              where
                                process.Id != currentProcess.Id &&
                                process.ProcessName.Equals(
                                  currentProcess.ProcessName,
                                  StringComparison.Ordinal)
                              select process).FirstOrDefault();
        if (runningProcess != null)
        {
            ShowWindow(runningProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
            SetForegroundWindow(runningProcess.MainWindowHandle);
            return false;
        }
        return true;
    }
    [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
    private const int SW_SHOWMAXIMIZED = 3;
