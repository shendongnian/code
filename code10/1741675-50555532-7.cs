    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Windows.Automation;
    using System.Windows.Forms;
    static class Program
    {
        static Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            Application.ThreadExit += new EventHandler(ThreadOnExit);
            string ApplicationMutex = "Global\BcFFcd23-3456-6543-Fc44abcd1234";
            mutex = new Mutex(true, ApplicationMutex);
            bool SingleInstance = mutex.WaitOne(0, false);
            if (!SingleInstance)
            {
                MessageBox.Show("Application already running", "[MyApplicationMainFormText]", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                string AppProductName = Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductName;
                Process[] WindowedProcesses = Process.GetProcesses()
                                                     .Where(p => p.MainWindowHandle != IntPtr.Zero).ToArray();
                foreach (Process process in WindowedProcesses.Where(p => p.MainModule.FileVersionInfo.ProductName == AppProductName))
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                        if (!element.Current.IsOffscreen)
                        {
                            WindowPattern WPattern = element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                            WindowInteractionState state = WPattern.Current.WindowInteractionState;
                            WPattern.SetWindowVisualState(WindowVisualState.Normal);
                            break;
                        }
                    }
                }
            }
            if (SingleInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyAppMainForm());
            }
            else
            {
                Application.ExitThread();
            }
        }
        private static void ThreadOnExit(object s, EventArgs e)
        {
            mutex.Close();
            mutex.Dispose();
            Application.ThreadExit -= ThreadOnExit;
            Application.Exit();
        }
    }
