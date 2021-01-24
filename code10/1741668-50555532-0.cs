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
            string ApplicationMutex = "BcFFcd23-3456-6543-Fc44abcd1234";
            mutex = new Mutex(true, ApplicationMutex);
            bool SingleInstance = mutex.WaitOne(0, false);
            if (!SingleInstance)
            {
                MessageBox.Show("Application already running");
                string AppProductName = Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductName;
                Process[] WindowedProcesses = Process.GetProcesses()
                                                     .Where(p => p.MainWindowHandle != IntPtr.Zero).ToArray();
                foreach (Process process in WindowedProcesses.Where(p => p.MainModule.FileVersionInfo.ProductName == AppProductName))
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                        WindowPattern WPattern = element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                        WPattern.SetWindowVisualState(WindowVisualState.Normal);
                        break;
                    }
                }
            }
            if (SingleInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
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
