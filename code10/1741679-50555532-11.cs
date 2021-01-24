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
            Application.ThreadExit += ThreadOnExit;
            string applicationMutex = @"Global\BcFFcd23-3456-6543-Fc44abcd1234";
            mutex = new Mutex(true, applicationMutex);
            bool singleInstance = mutex.WaitOne(0, false);
            if (!singleInstance)
            {
                string appProductName = Process.GetCurrentProcess().MainModule.FileVersionInfo.ProductName;
                Process[] windowedProcesses = 
                    Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero).ToArray();
                foreach (Process process in windowedProcesses.Where(p => p.MainModule.FileVersionInfo.ProductName == appProductName))
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        AutomationElement wElement = AutomationElement.FromHandle(process.MainWindowHandle);
                        if (wElement.Current.IsOffscreen)
                        {
                            WindowPattern wPattern = wElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                            #if DEBUG
                            WindowInteractionState state = wPattern.Current.WindowInteractionState;
                            Debug.Assert(!(state == WindowInteractionState.NotResponding), "The application is not responding");
                            Debug.Assert(!(state == WindowInteractionState.BlockedByModalWindow), "Main Window blocked by a Modal Window");
                            #endif
                            wPattern.SetWindowVisualState(WindowVisualState.Normal);
                            break;
                        }
                    }
                }
                Thread.Sleep(200);
                MessageBox.Show("Application already running", "MyApplicationName",
                                MessageBoxButtons.OK, MessageBoxIcon.Information, 
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            if (SingleInstance) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyAppMainForm());
            }
            else {
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
